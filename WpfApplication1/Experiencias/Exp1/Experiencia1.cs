using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WpfApplication1.Experiencias.Exp1
{
    [Serializable]
    public class Experiencia1 : Experiencia, ISerializable
    {
        private const int ValsPerProtocol = 15;
        private readonly List<ProtocoloExp1> _protocolos;


        public Experiencia1(int nProtocolos) : base(4020)

        {
            //Puerto = 4020;

            FBuffer = new float[4 + ValsPerProtocol*nProtocolos];

            NumberOfProtocols = nProtocolos;

            _protocolos = new List<ProtocoloExp1>(NumberOfProtocols);

            for (int i = 0; i < NumberOfProtocols; i++)
            {
                _protocolos.Add(new ProtocoloExp1(i));
            }
        }

        public Experiencia1(SerializationInfo info, StreamingContext ctxt) : base(4020)
        {
            //recibe = false;
            //Puerto = 4020;
            NumberOfProtocols = (int) info.GetValue("NProtocolos", typeof (int));
            FBuffer = new float[4 + ValsPerProtocol*NumberOfProtocols];

            Random = (bool) info.GetValue("Random", typeof (bool));
            CyclesBetweenPulses = (int) info.GetValue("CyclesBetweenPulses", typeof (int));

            //_protocolos = new List<ProtocoloExp1>(10);
            _protocolos = (List<ProtocoloExp1>) info.GetValue("Protocolos", typeof (List<ProtocoloExp1>));
        }

        public List<ProtocoloExp1> Protocolos
        {
            get { return _protocolos; }
        }

        public Byte[] ReceivedBytes { get; set; }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Random", Random);
            info.AddValue("CyclesBetweenPulses", CyclesBetweenPulses);
            info.AddValue("Protocolos", _protocolos);
            info.AddValue("NProtocolos", NumberOfProtocols);
        }

        #endregion

        public ProtocoloExp1 GetProtocolo(int i)
        {
            return _protocolos[i];
        }

        public void SetProtocolo(int i, ProtocoloExp1 protocolo)
        {
            Protocolos[i].ActivateAnimation = protocolo.ActivateAnimation;
            Protocolos[i].ActivateSound = protocolo.ActivateSound;
            Protocolos[i].ActiveFrequency = protocolo.ActiveFrequency;
            Protocolos[i].AnimationBlending = protocolo.AnimationBlending;
            Protocolos[i].CiclosEntrePulso = protocolo.CiclosEntrePulso;
            Protocolos[i].CyclesNextProtocol = protocolo.CyclesNextProtocol;
            Protocolos[i].Invertir = protocolo.Invertir;
            Protocolos[i].IsActive = protocolo.IsActive;
            Protocolos[i].PassiveFrequency = protocolo.PassiveFrequency;
            Protocolos[i].PostPassiveFrequency = protocolo.PostPassiveFrequency;
            Protocolos[i].PrioridadCiclos = protocolo.PrioridadCiclos;
            Protocolos[i].SoundFrequency = protocolo.SoundFrequency;
            Protocolos[i].SoundSync = protocolo.SoundSync;
            Protocolos[i].TimeNextProtocol = protocolo.TimeNextProtocol;
            Protocolos[i].EnNegro = protocolo.EnNegro;
        }

        protected override void PackData()
        {
            //Los 4 primeros son comunes
            FBuffer[0] = Started ? 1 : 0;
            FBuffer[1] = Random ? 1 : 0;
            FBuffer[2] = CyclesBetweenPulses;
            FBuffer[3] = ResetSignal ? 1.0f : 0.0f;
            //Los restantes son para los parametros dew los protocolos
            //deberia enviar structs, pero ya me estan metiendo prisa otra vez ASI QUE PASO

            for (int i = 0; i < NumberOfProtocols; i++)
            {
                int indice = (i*ValsPerProtocol) + 4;
                FBuffer[indice + 0] = _protocolos[i].Invertir ? 1 : 0;
                FBuffer[indice + 1] = _protocolos[i].TimeNextProtocol;
                FBuffer[indice + 2] = _protocolos[i].CyclesNextProtocol;
                FBuffer[indice + 3] = _protocolos[i].ActivateSound ? 1 : 0;
                FBuffer[indice + 4] = _protocolos[i].SoundSync ? 1 : 0;
                FBuffer[indice + 5] = _protocolos[i].SoundFrequency;
                FBuffer[indice + 6] = _protocolos[i].ActivateAnimation ? 1 : 0;
                FBuffer[indice + 7] = _protocolos[i].PassiveFrequency;
                FBuffer[indice + 8] = 1/_protocolos[i].ActiveFrequency;
                FBuffer[indice + 9] = ((_protocolos[i].AnimationBlending)/100.0f);
                FBuffer[indice + 10] = _protocolos[i].IsActive ? 1 : 0;
                FBuffer[indice + 11] = _protocolos[i].CiclosEntrePulso;
                FBuffer[indice + 12] = _protocolos[i].PrioridadCiclos ? 1 : 0;
                FBuffer[indice + 13] = _protocolos[i].PostPassiveFrequency;
                FBuffer[indice + 14] = _protocolos[i].EnNegro ? 1 : 0;
            }

            ResetSignal = false;
        }
    }
}