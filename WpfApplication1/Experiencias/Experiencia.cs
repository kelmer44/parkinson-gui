using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Windows;

namespace WpfApplication1.Experiencias
{
    public abstract class Experiencia: INotifyPropertyChanged
    {
        #region Estados enum

        public enum Estados
        {
            NotStarted = 0,
            Running = 1,
            Stopped = 2,
            Stopping = 3,
            Restarting = 4
        }

        #endregion

        private Estados _estado;
        private int _currentProtocol;


        public float[] FBuffer { get; set; }

        public bool Started { get; set; }

        public int Puerto { get; set; }

        protected abstract void PackData();

        readonly UdpClient _udpClient = new UdpClient();

        public bool ResetSignal;

        public int CurrentProtocol
        {
            get { return _currentProtocol; }
            set
            {
                if (value != _currentProtocol)
                {
                    _currentProtocol = value;
                    NotifyPropertyChanged("CurrentProtocol");
                }
            }
        }

        public Estados Estado
        {
            get { return _estado; }
            set
            {
                if (value != _estado)
                {
                    _estado = value;
                    NotifyPropertyChanged("Estado");
                }
            }
        }

        public bool Random { get; set; }

        public bool IsStarted { get; set; }

        public int CyclesBetweenPulses { get; set; }

        public int NumberOfProtocols { get; set; }


        protected Experiencia(int puerto)
        {
            Puerto = puerto;

            _udpClient.EnableBroadcast = true;
            _udpClient.Connect(IPAddress.Broadcast, Puerto);
            _udpClient.Ttl = 10;
        }

        // Funcion  para empaquetar los datos en los sockets
        private byte[] GetBytes()
        {
            //Concatenamos cada representacion del float como byte para enviar una ristra de bytes que en el programa en C++ seran interpretados como float
            var buff = new byte[sizeof (float)*FBuffer.Length];
            var aux = new byte[sizeof (float)];
            for (int i = 0; i < FBuffer.Length; i++)
            {
                aux = BitConverter.GetBytes(FBuffer[i]);
                Buffer.BlockCopy(aux, 0, buff, i*sizeof (float), sizeof (float));
            }

            return buff;
        }

        public void CloseConnection()
        {
            _udpClient.Close();
        }

        public void EnviaDatos()
        {
            PackData();
            byte[] sendBytes = null;

            sendBytes = GetBytes();
            try
            {
                _udpClient.Send(sendBytes, sendBytes.Length);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //udpClient.E();
        }


        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }

}