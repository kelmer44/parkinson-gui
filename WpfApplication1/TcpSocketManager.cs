using System;
using System.Threading;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using XYThreadPoolLib;

namespace WpfApplication1
{
    public delegate void ExceptionHandlerDelegate(Exception oBug);
    public delegate void ConnectionFilterDelegate(String sRemoteAddress, int nRemotePort, Socket sock);
    public delegate void BinaryInputHandlerDelegate(String sRemoteAddress, int nRemotePort, Byte[] pData);
    public delegate void StringInputHandlerDelegate(String sRemoteAddress, int nRemotePort, String sData);

    public class XyNetServer
    {
        private delegate void AcceptClientsDelegate();
        private delegate void DetectInputDelegate();
        private delegate void ProcessInputDelegate(Socket sock, IPEndPoint ipe);

        private const int MnServerPause = 25;
        private const int MnListenBacklog = 32;
        private const int MnArrayCapacity = 512;
        private int _mNReadTimeout = 30;
        private int _mNMaxDataSize = 4 * 1024 * 1024;
        private readonly int _mNMinThreadCount = 7;
        private readonly int _mNMaxThreadCount = 12;
        private readonly String _mSAddress = "";
        private readonly int _mNPort;
        private Socket _mSocketServer;
        private readonly XYThreadPool _mThreadPool = new XYThreadPool();
        private readonly Hashtable _mHtSockets = new Hashtable(MnArrayCapacity);
        private readonly ArrayList _mListSockets = new ArrayList(MnArrayCapacity);
        private ConnectionFilterDelegate _mDelegateConnectionFilter;
        private ExceptionHandlerDelegate _mDelegateExceptionHandler;
        private BinaryInputHandlerDelegate _mDelegateBinaryInputHandler;
        private StringInputHandlerDelegate _mDelegateStringInputHandler;
        private Exception _mException;

        public XyNetServer(String sAddress, int nPort, int nMinThreadCount, int nMaxThreadCount)
        {
            if (sAddress != null) _mSAddress = sAddress;
            if (nPort > 0) _mNPort = nPort;
            if (nMinThreadCount > 0) _mNMinThreadCount = nMinThreadCount + 2;
            if (nMinThreadCount > 0 && nMaxThreadCount > nMinThreadCount) _mNMaxThreadCount = nMaxThreadCount + 2;
            else _mNMaxThreadCount = 2 * (_mNMinThreadCount - 2) + 2;
        }

        ~XyNetServer()
        {
            StopServer();
        }

        public Exception GetLastException()
        {
            Monitor.Enter(this);
            var exp = _mException;
            Monitor.Exit(this);
            return exp;
        }

        public void StopServer()
        {
            try
            {
                Monitor.Enter(this);
                _mThreadPool.StopThreadPool();
                if (_mSocketServer != null)
                {
                    Socket sock;
                    foreach (var t in _mListSockets)
                    {
                        sock = (Socket)(t);
                        try
                        {
                            sock.Shutdown(SocketShutdown.Both);
                            sock.Close();
                        }
                        catch (Exception)
                        { }
                    }
                    try
                    {
                        _mSocketServer.Shutdown(SocketShutdown.Both);
                        _mSocketServer.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
            catch (Exception) { }
            finally
            {
                try
                {
                    _mSocketServer = null;
                    _mHtSockets.Clear();
                    _mListSockets.Clear();
                }
                catch (Exception) { }
                Monitor.Exit(this);
            }
        }

        public bool StartServer()
        {
            try
            {
                Monitor.Enter(this);
                XyNetCommon.SetSocketPermission();
                StopServer();
                _mThreadPool.SetThreadErrorHandler(ThreadErrorHandler);
                _mThreadPool.StartThreadPool(_mNMinThreadCount, _mNMaxThreadCount);
                _mSocketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _mSocketServer.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
                var myEnd = (_mSAddress == "") ? (new IPEndPoint(Dns.GetHostByName(Dns.GetHostName()).AddressList[0], _mNPort)) : (new IPEndPoint(IPAddress.Parse(_mSAddress), _mNPort));
                _mSocketServer.Bind(myEnd);
                _mSocketServer.Listen(MnListenBacklog);
                _mThreadPool.InsertWorkItem("Accept Clients", new AcceptClientsDelegate(AcceptClients), null, false);
                _mThreadPool.InsertWorkItem("Detect Input", new DetectInputDelegate(DetectInput), null, false);
                return true;
            }
            catch (Exception oBug)
            {
                _mException = oBug;
                return false;
            }
            finally { Monitor.Exit(this); }
        }

        public void SetReadTimeout(int nReadTimeout)
        {
            Monitor.Enter(this);
            if (nReadTimeout >= 5 && nReadTimeout <= 1200) _mNReadTimeout = nReadTimeout;
            Monitor.Exit(this);
        }

        public void SetMaxDataSize(int nMaxDataSize)
        {
            Monitor.Enter(this);
            if (nMaxDataSize >= 1024) _mNMaxDataSize = nMaxDataSize;
            Monitor.Exit(this);
        }

        public void SetConnectionFilter(ConnectionFilterDelegate pMethod)
        {
            Monitor.Enter(this);
            if (_mDelegateConnectionFilter == null) _mDelegateConnectionFilter = pMethod;
            Monitor.Exit(this);
        }

        public void SetExceptionHandler(ExceptionHandlerDelegate pMethod)
        {
            Monitor.Enter(this);
            if (_mDelegateExceptionHandler == null) _mDelegateExceptionHandler = pMethod;
            Monitor.Exit(this);
        }

        public void SetBinaryInputHandler(BinaryInputHandlerDelegate pMethod)
        {
            Monitor.Enter(this);
            if (_mDelegateBinaryInputHandler == null) _mDelegateBinaryInputHandler = pMethod;
            Monitor.Exit(this);
        }

        public void SetStringInputHandler(StringInputHandlerDelegate pMethod)
        {
            Monitor.Enter(this);
            if (_mDelegateStringInputHandler == null) _mDelegateStringInputHandler = pMethod;
            Monitor.Exit(this);
        }

        private void ThreadErrorHandler(ThreadPoolWorkItem oWorkItem, Exception oBug)
        {
            try
            {
                Monitor.Enter(this);
                if (_mDelegateExceptionHandler != null)
                {
                    _mThreadPool.InsertWorkItem("Handle Exception", _mDelegateExceptionHandler, new Object[] { oBug }, false);
                }
                else _mException = oBug;
            }
            catch (Exception) { }
            finally { Monitor.Exit(this); }
        }

        private void AcceptClients()
        {
            while (true)
            {
                var bHasNewClient = false;
                Socket sock = null;
                try
                {
                    if (_mSocketServer.Poll(MnServerPause, SelectMode.SelectRead))
                    {
                        bHasNewClient = true;
                        sock = _mSocketServer.Accept();
                        var ipe = (IPEndPoint)(sock.RemoteEndPoint);
                        if (_mDelegateConnectionFilter != null)
                        {
                            _mDelegateConnectionFilter.DynamicInvoke(new Object[] { ipe.Address.ToString(), ipe.Port, sock });
                        }
                        if (sock.Connected)
                        {
                            var sKey = ipe.Address + ":" + ipe.Port;
                            Monitor.Enter(this);
                            _mHtSockets.Add(sKey, sock);
                            _mListSockets.Add(sock);
                            Monitor.Exit(this);
                        }
                    }
                }
                catch (Exception oBug)
                {
                    if (sock != null)
                    {
                        try
                        {
                            sock.Shutdown(SocketShutdown.Both);
                            sock.Close();
                        }
                        catch (Exception) { }
                    }
                    if (_mDelegateExceptionHandler != null)
                    {
                        _mThreadPool.InsertWorkItem("Handle Exception", _mDelegateExceptionHandler, new Object[] { oBug }, false);
                    }
                    else
                    {
                        Monitor.Enter(this);
                        _mException = oBug;
                        Monitor.Exit(this);
                    }
                }
                if (bHasNewClient) Thread.Sleep(MnServerPause);
                else Thread.Sleep(10 * MnServerPause);
            }
        }

        private void DetectInput()
        {
            var nCounter = 0;
            while (true)
            {
                nCounter++;
                var bNoData = true;
                try
                {
                    for (var i = _mListSockets.Count - 1; i >= 0; i--)
                    {
                        Socket sock = null;
                        IPEndPoint ipe = null;
                        try
                        {
                            sock = (Socket)(_mListSockets[i]);
                            ipe = (IPEndPoint)(sock.RemoteEndPoint);
                            if (!sock.Connected) throw new Exception("Connection to client closed");
                            if (nCounter % 1000 == 0)
                            {
                                if (sock.Send(new Byte[] { 2, 0, 0, 0 }) != 4)
                                    throw new Exception("Failed to ping client socket");
                            }
                            if (sock.Available > 0)
                            {
                                Monitor.Enter(this);
                                _mListSockets.RemoveAt(i);
                                Monitor.Exit(this);
                                bNoData = false;
                                _mThreadPool.InsertWorkItem("Process Input", new ProcessInputDelegate(ProcessInput), new Object[] { sock, ipe }, false);
                            }
                        }
                        catch (Exception oBug)
                        {
                            if (i >= 0 && sock != null)
                            {
                                Monitor.Enter(this);
                                _mListSockets.RemoveAt(i);
                                if (ipe != null) _mHtSockets.Remove(ipe.Address + ":" + ipe.Port);
                                Monitor.Exit(this);
                                try
                                {
                                    sock.Shutdown(SocketShutdown.Both);
                                    sock.Close();
                                }
                                catch (Exception) { }
                            }
                            if (_mDelegateExceptionHandler != null)
                            {
                                _mThreadPool.InsertWorkItem("Handle Exception", _mDelegateExceptionHandler, new Object[] { oBug }, false);
                            }
                        }
                    }
                    if (bNoData) Thread.Sleep(10 * MnServerPause);
                    else Thread.Sleep(MnServerPause);
                }
                catch (Exception) { }
            }
        }

        private void ProcessInput(Socket sock, IPEndPoint ipe)
        {
            try
            {
                var pHeader = new Byte[4];
                var nPos = 0;
                var nStart = DateTime.Now.Ticks;
                while (nPos < 4)
                {
                    if (sock.Available > 0)
                    {
                        nPos += sock.Receive(pHeader, nPos, Math.Min(sock.Available, (4 - nPos)), SocketFlags.None);
                        if ((pHeader[0] & 0x000000FF) == 255)
                        {
                            sock.Shutdown(SocketShutdown.Both);
                            sock.Close();
                            Monitor.Enter(this);
                            _mHtSockets.Remove(ipe.Address + ":" + ipe.Port);
                            Monitor.Exit(this);
                            return;
                        }
                    }
                    else Thread.Sleep(MnServerPause);
                    if (nPos < 4 && ((DateTime.Now.Ticks - nStart) / 10000) > _mNReadTimeout * 1000) throw new Exception("Timeout while receiving incoming data");
                }
                if ((pHeader[0] & 0x0000000F) != 2)
                {
                    var nSize = pHeader[1] + pHeader[2] * 256 + pHeader[3] * 65536 + (pHeader[0] / 16) * 16777216;
                    if (nSize > _mNMaxDataSize) throw new Exception("Data size too large");
                    var pData = new Byte[nSize];
                    nPos = 0;
                    nStart = DateTime.Now.Ticks;
                    while (nPos < nSize)
                    {
                        if (sock.Available > 0)
                        {
                            nPos += sock.Receive(pData, nPos, Math.Min(sock.Available, (nSize - nPos)), SocketFlags.None);
                        }
                        else Thread.Sleep(MnServerPause);
                        if (nPos < nSize && ((DateTime.Now.Ticks - nStart) / 10000) > _mNReadTimeout * 1000) throw new Exception("Timeout while receiving incoming data");
                    }
                    Monitor.Enter(this);
                    _mListSockets.Add(sock);
                    Monitor.Exit(this);
                    switch ((pHeader[0] & 0x0000000F))
                    {
                        case 1:
                            if (_mDelegateBinaryInputHandler != null)
                            {
                                _mThreadPool.InsertWorkItem("Handle Binary Input", new BinaryInputHandlerDelegate(_mDelegateBinaryInputHandler), new Object[] { ipe.Address.ToString(), ipe.Port, pData }, false);
                            }
                            else throw new Exception("No binary input handler");
                            break;
                        case 0:
                            if (_mDelegateStringInputHandler != null)
                            {
                                _mThreadPool.InsertWorkItem("Handle String Input", new StringInputHandlerDelegate(_mDelegateStringInputHandler), new Object[] { ipe.Address.ToString(), ipe.Port, XyNetCommon.BinaryToString(pData) }, false);
                            }
                            else throw new Exception("No string input handler");
                            break;
                        default:
                            throw new Exception("Invalid string data size");
                    }
                }
            }
            catch (Exception oBug)
            {
                Monitor.Enter(this);
                _mHtSockets.Remove(ipe.Address + ":" + ipe.Port);
                Monitor.Exit(this);
                try
                {
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                }
                catch (Exception) { }
                if (_mDelegateExceptionHandler != null)
                {
                    _mThreadPool.InsertWorkItem("Handle Exception", _mDelegateExceptionHandler, new Object[] { oBug }, false);
                }
                else
                {
                    Monitor.Enter(this);
                    _mException = oBug;
                    Monitor.Exit(this);
                }
            }
        }

        private bool SendRawData(String sRemoteAddress, int nRemotePort, Byte[] pData)
        {
            if (sRemoteAddress == null || pData == null) return false;
            Socket sock = null;
            try
            {
                Monitor.Enter(this);
                sock = (Socket)(_mHtSockets[sRemoteAddress + ":" + nRemotePort]);
                if (sock == null) throw new Exception("No client connection at the given address and port");
                if (_mListSockets.Contains(sock) == false)
                {
                    sock = null;
                    throw new Exception("Client socket in use");
                }
                return sock.Send(pData) == pData.Length;
            }
            catch (Exception oBug)
            {
                try
                {
                    if (sock != null)
                    {
                        sock.Shutdown(SocketShutdown.Both);
                        sock.Close();
                    }
                }
                catch (Exception) { }
                if (_mDelegateExceptionHandler != null)
                {
                    _mThreadPool.InsertWorkItem("Handle Exception", _mDelegateExceptionHandler, new Object[] { oBug }, false);
                }
                else _mException = oBug;
                return false;
            }
            finally { Monitor.Exit(this); }
        }

        public bool SendBinaryData(String sRemoteAddress, int nRemotePort, Byte[] pData)
        {
            var pData2 = new Byte[pData.Length + 4];
            pData2[0] = (Byte)(1 + (pData.Length / 16777216) * 16);
            pData2[1] = (Byte)(pData.Length % 256);
            pData2[2] = (Byte)((pData.Length % 65536) / 256);
            pData2[3] = (Byte)((pData.Length / 65536) % 256);
            pData.CopyTo(pData2, 4);
            return SendRawData(sRemoteAddress, nRemotePort, pData2);
        }

        public bool SendStringData(String sRemoteAddress, int nRemotePort, String sData)
        {
            var pData = new Byte[sData.Length * 2 + 4];
            pData[0] = (Byte)(((2 * sData.Length) / 16777216) * 16);
            pData[1] = (Byte)((2 * sData.Length) % 256);
            pData[2] = (Byte)(((2 * sData.Length) % 65536) / 256);
            pData[3] = (Byte)(((2 * sData.Length) / 65536) % 256);
            XyNetCommon.StringToBinary(sData).CopyTo(pData, 4);
            return SendRawData(sRemoteAddress, nRemotePort, pData);
        }

        public int GetThreadCount()
        {
            var nCount = _mThreadPool.GetThreadCount() - 2;
            return nCount > 0 ? nCount : 0;
        }

        public int GetClientCount()
        {
            Monitor.Enter(this);
            var nCount = _mHtSockets.Count;
            Monitor.Exit(this);
            return nCount;
        }
    }

    public class XyNetClient
    {
        private const int MnClientPause = 50;
        private readonly String _mSRemoteAddress = "";
        private readonly int _mNRemotePort;
        private int _mNMaxDataSize = 4 * 1024 * 1024;
        private int _mNReadTimeout = 30;
        private Exception _mException;
        private Socket _mSocketClient;

        public XyNetClient(String sRemoteAddress, int nRemotePort)
        {
            if (sRemoteAddress != null) _mSRemoteAddress = sRemoteAddress;
            if (nRemotePort > 0) _mNRemotePort = nRemotePort;
        }

        ~XyNetClient()
        {
            Reset();
        }

        public Exception GetLastException()
        {
            Monitor.Enter(this);
            var exp = _mException;
            Monitor.Exit(this);
            return exp;
        }

        public void SetMaxDataSize(int nMaxDataSize)
        {
            if (nMaxDataSize >= 1024) _mNMaxDataSize = nMaxDataSize;
        }

        protected Socket GetSocket()
        {
            Monitor.Enter(this);
            var sock = _mSocketClient;
            Monitor.Exit(this);
            return sock;
        }

        public virtual bool Connect()
        {
            try
            {
                Monitor.Enter(this);
                XyNetCommon.SetSocketPermission();
                Reset();
                _mSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint myEnd = null;
                try
                {
                    myEnd = (_mSRemoteAddress == "") ? (new IPEndPoint(Dns.GetHostByName(Dns.GetHostName()).AddressList[0], _mNRemotePort)) : (new IPEndPoint(IPAddress.Parse(_mSRemoteAddress), _mNRemotePort));
                }
                catch (Exception) { }
                if (myEnd == null)
                {
                    myEnd = new IPEndPoint(Dns.GetHostByName(_mSRemoteAddress).AddressList[0], _mNRemotePort);
                }
                _mSocketClient.Connect(myEnd);
                return true;
            }
            catch (Exception oBug)
            {
                _mException = oBug;
                try
                {
                    _mSocketClient.Shutdown(SocketShutdown.Both);
                    _mSocketClient.Close();
                }
                catch (Exception) { }
                return false;
            }
            finally { Monitor.Exit(this); }
        }

        private bool SendRawData(Byte[] pData)
        {
            try
            {
                Monitor.Enter(this);
                return _mSocketClient.Send(pData) == pData.Length;
            }
            catch (Exception oBug)
            {
                Connect();
                _mException = oBug;
                return false;
            }
            finally { Monitor.Exit(this); }
        }

        public bool SendBinaryData(Byte[] pData)
        {
            var pData2 = new Byte[pData.Length + 4];
            pData2[0] = (Byte)(1 + (pData.Length / 16777216) * 16);
            pData2[1] = (Byte)(pData.Length % 256);
            pData2[2] = (Byte)((pData.Length % 65536) / 256);
            pData2[3] = (Byte)((pData.Length / 65536) % 256);
            pData.CopyTo(pData2, 4);
            return SendRawData(pData2);
        }

        public bool SendStringData(String sData)
        {
            var pData = new Byte[sData.Length * 2 + 4];
            pData[0] = (Byte)(((2 * sData.Length) / 16777216) * 16);
            pData[1] = (Byte)((2 * sData.Length) % 256);
            pData[2] = (Byte)(((2 * sData.Length) % 65536) / 256);
            pData[3] = (Byte)(((2 * sData.Length) / 65536) % 256);
            XyNetCommon.StringToBinary(sData).CopyTo(pData, 4);
            return SendRawData(pData);
        }

        public void SetReadTimeout(int nReadTimeout)
        {
            Monitor.Enter(this);
            if (nReadTimeout >= 5 && nReadTimeout <= 1200) _mNReadTimeout = nReadTimeout;
            Monitor.Exit(this);
        }

        public Object[] ReceiveData()
        {
            try
            {
                Monitor.Enter(this);
                _mSocketClient.Blocking = false;
                var nStart = DateTime.Now.Ticks;
                var nRead = 0;
                var nTotal = 4;
                var pData = new Byte[4];
                Byte[] pHeader = null;
                while (true)
                {
                    try
                    {
                        Thread.Sleep(MnClientPause);
                        if (_mSocketClient.Available > 0)
                        {
                            nRead += _mSocketClient.Receive(pData, nRead, nTotal - nRead, SocketFlags.None);
                            if ((pData[0] & 0x0000000F) == 2) nRead = 0;
                        }
                    }
                    catch (Exception) { }
                    if (pHeader == null && nRead == 4)
                    {
                        nTotal = (pData[1] & 0x000000FF) + (pData[2] & 0x000000FF) * 256 + (pData[3] & 0x000000FF) * 65536 + ((pData[0] & 0x000000FF) / 16) * 16777216;
                        if ((pData[0] & 0x0000000F) > 1) throw new Exception("Invalid input data type byte");
                        if (nTotal > _mNMaxDataSize) throw new Exception("Data size too large");
                        pHeader = pData;
                        nRead = 0;
                        pData = new Byte[nTotal];
                    }
                    if (pHeader != null && nRead == nTotal) break;
                    if (((DateTime.Now.Ticks - nStart) / 10000) > _mNReadTimeout * 1000) throw new Exception("Timeout while receiving incoming data");
                }
                if ((pHeader[0] & 0x0000000F) == 1)
                {
                    return new Object[] { pData, null };
                }
                else
                {
                    if (pData.Length % 2 != 0) throw new Exception("Invalid string data size");
                    return new Object[] { null, XyNetCommon.BinaryToString(pData) };
                }
            }
            catch (Exception oBug)
            {
                Connect();
                _mException = oBug;
                return null;
            }
            finally
            {
                _mSocketClient.Blocking = true;
                Monitor.Exit(this);
            }
        }

        public void Reset()
        {
            try
            {
                Monitor.Enter(this);
                if (_mSocketClient != null)
                {
                    _mSocketClient.Send(new Byte[] { 255, 0, 0, 0 }, SocketFlags.None);
                    _mSocketClient.Shutdown(SocketShutdown.Both);
                    _mSocketClient.Close();
                }
            }
            catch (Exception) { }
            finally
            {
                _mSocketClient = null;
                Monitor.Exit(this);
            }
        }
    }

    public class XyNetCommon
    {
        public static SocketPermission MPermissionSocket;
        private static bool _mBPermissionSet;

        public static void SetSocketPermission()
        {
            lock (typeof(XyNetCommon))
            {
                if (_mBPermissionSet) return;
                if (MPermissionSocket != null)
                {
                    MPermissionSocket.Demand();
                }
                _mBPermissionSet = true;
            }
        }

        public static String BinaryToString(Byte[] pData)
        {
            if ((pData.Length % 2) != 0) throw new Exception("Invalid string data size");
            var pChar = new Char[pData.Length / 2];
            for (var i = 0; i < pChar.Length; i++)
            {
                pChar[i] = (Char)((pData[2 * i] & 0x000000FF) + (pData[2 * i + 1] & 0x000000FF) * 256);
            }
            return new String(pChar);
        }

        public static Byte[] StringToBinary(String sData)
        {
            var pData = new Byte[sData.Length * 2];
            for (var i = 0; i < sData.Length; i++)
            {
                pData[2 * i] = (Byte)((sData[i] & 0x000000FF) % 256);
                pData[2 * i + 1] = (Byte)((sData[i] & 0x0000FF00) / 256);
            }
            return pData;
        }
    }
}
