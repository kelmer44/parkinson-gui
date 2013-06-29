using System;
using System.Net;
using System.Net.Sockets;

namespace WpfApplication1
{
    public class SocketManager
    {
        private static SocketManager _instance;
        static readonly object Padlock = new object();

        private IPEndPoint _e;
        private UdpClient _u;
        private UdpState _s;


        public static bool MessageReceived = true;
        
        private SocketManager()
        {
            
        }

        public byte[] ReceivedBytes { get; private set; }

        public static SocketManager Instance
        {
            get
            {
                lock(Padlock)
                {
                    return _instance ?? (_instance = new SocketManager());
                }
            }
        }

        public void CreateReceivingSocket(IPAddress a, int puerto)
        {
            
            if(_e==null || (_e.Address != a && _e.Port != puerto))
            {
                _e = new IPEndPoint(a, puerto);
                _u = new UdpClient(puerto);
                _s = new UdpState { E = _e, U = _u };
            }
           
        }


        public void ReceiveCallback(IAsyncResult ar)
        {
            UdpClient u = ((UdpState)(ar.AsyncState)).U;
            IPEndPoint e = ((UdpState)(ar.AsyncState)).E;

            ReceivedBytes = u.EndReceive(ar, ref e);
            //int currentProtocol = (int) numero;
            //ResetSignal = reset > 0;
           
            //Console.WriteLine("Received: " + currentProtocol);
            MessageReceived = true;
        }

        public void RecibeDatos()
        {
            if (MessageReceived && _u != null && _s != null)
            {
                MessageReceived = false;
                //Console.WriteLine("listening for messages");
                _u.BeginReceive(ReceiveCallback, _s);
            }
        }

        public void CloseConnection()
        {
            if (_e != null)
            {
                _e.Port = 5502;
                _e = null;
            }
            if (_u != null)
                _u.Close();

        }
    }

    public class UdpState
    {
        public IPEndPoint E;
        public UdpClient U;
    }
}