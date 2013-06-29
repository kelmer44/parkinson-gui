using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace WpfApplication1.Experiencias.Exp3
{
    [Serializable]
    public class Experiencia3 : Experiencia, ISerializable
    {
        #region CameraType enum

        public enum CameraType
        {
            Primera = 0,
            Tercera = 1
        } ;

        #endregion

        private List<PuertaExp3> _puertas; /* = new PuertaExp3[10]
                                            {
                                                new PuertaExp3(), new PuertaExp3(), new PuertaExp3(), new PuertaExp3(),
                                                new PuertaExp3(), new PuertaExp3(), new PuertaExp3(), new PuertaExp3(),
                                                new PuertaExp3(), new PuertaExp3()
                                            };*/

        private Socket _socket = new TcpClient().Client;

        public Experiencia3():base(4023)
        {
            Puerto = 4023;

            FBuffer = new float[30];

            _puertas = new List<PuertaExp3>(10);

            for (int i = 0; i < 10; i++)
            {
                _puertas.Add(new PuertaExp3());
            }
        }

        public Experiencia3(SerializationInfo info, StreamingContext ctxt):base(4023)
        {
            //recibe = false;
            //Puerto = 4023;

            FBuffer = new float[30];

            
            TipoCamara = (CameraType) info.GetValue("TipoCamara", typeof (CameraType));
            AutoAnim = (bool) info.GetValue("AutoAnim", typeof (bool));
            DoorSize = (float)info.GetValue("DoorSize", typeof(float));
            ArmSpread = (float)info.GetValue("ArmSpread", typeof(float));
            AnimSpeed = (float)info.GetValue("AnimSpeed", typeof(float));
            
            _puertas = (List<PuertaExp3>) info.GetValue("Puertas", typeof (List<PuertaExp3>));
        }


        public CameraType TipoCamara { get; set; }

        public bool AutoAnim { get; set; }

        public float DoorSize { get; set; }

        public float AnimSpeed { get; set; }

        public float ArmSpread { get; set; }

        public List<PuertaExp3> Puertas
        {
            get { return _puertas; }
            set { _puertas = value; }
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TipoCamara", TipoCamara);
            info.AddValue("AutoAnim", AutoAnim);
            info.AddValue("DoorSize", DoorSize);
            info.AddValue("ArmSpread", ArmSpread);
            info.AddValue("AnimSpeed", AnimSpeed);
            info.AddValue("Puertas", _puertas);
        }

        #endregion

        public PuertaExp3 GetPuerta(int i)
        {
            return _puertas[i];
        }

        protected override void PackData()
        {
            /*
            * #define EXP04_INICIALIZAR         0
            #define EXP04_ANIM_CONTROL        1
            #define EXP04_VEL_ANIM            2
            #define EXP04_TAM_PUERTA          3
            #define EXP04_CAM_TYPE            4
            #define EXP04_AM_BRAZOS           5
            #define EXP04_PUERTA_1            6
            #define EXP04_PUERTA_2            7
            #define EXP04_PUERTA_3            8
            #define EXP04_PUERTA_4            9
            #define EXP04_PUERTA_5            10
            #define EXP04_PUERTA_6            11
            #define EXP04_PUERTA_7            12
            #define EXP04_PUERTA_8            13
            #define EXP04_PUERTA_9            14
            #define EXP04_PUERTA_10           15
            #define EXP04_RESET               16
            * */

            FBuffer[0] = Started ? 1 : 0;
            FBuffer[1] = AutoAnim ? 1 : 0;
            FBuffer[2] = AnimSpeed;
            //FBuffer[3] = DoorSize;
            FBuffer[4] = (int) TipoCamara;
            FBuffer[5] = ArmSpread;

            for (int i = 0; i < 10; i++)
            {
                //2 datos almacenados quí, más los 6 gneéricos de la experiencia
                int indice = (i*2) + 6;
                FBuffer[indice] = (int) GetPuerta(i).EstadoPuerta; //Abierta, cerrada, auto...
                FBuffer[indice+1] = GetPuerta(i).TamanoPuerta; //tamaño de esta puerta
            }
        }
    }
}