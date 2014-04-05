using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WpfApplication1.Experiencias.Exp2
{
    [Serializable]
    public class Experiencia2 : Experiencia, ISerializable
    {
        private const int ValsPerProtocol = 17;
        private readonly List<ProtocoloExp2> _protocolos;

        public Experiencia2(int nProtocolos) : base(4021)
        {
            //Puerto = 4021;

            FBuffer = new float[3 + ValsPerProtocol*nProtocolos];

            NumberOfProtocols = nProtocolos;

            _protocolos = new List<ProtocoloExp2>(NumberOfProtocols);

            for (int i = 0; i < NumberOfProtocols; i++)
            {
                _protocolos.Add(new ProtocoloExp2(i));
            }
        }

        public Experiencia2(SerializationInfo info, StreamingContext ctxt) : base(4021)
        {
            //recibe = false;
            //Puerto = 4021;
            NumberOfProtocols = (int) info.GetValue("NProtocolos", typeof (int));
            FBuffer = new float[3 + ValsPerProtocol*NumberOfProtocols];

            Random = (bool) info.GetValue("Random", typeof (bool));
            CyclesBetweenPulses = (int) info.GetValue("CyclesBetweenPulses", typeof (int));

            //_protocolos = new List<ProtocoloExp1>(10);
            _protocolos = (List<ProtocoloExp2>) info.GetValue("Protocolos", typeof (List<ProtocoloExp2>));
        }

        public List<ProtocoloExp2> Protocolos
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

        public ProtocoloExp2 GetProtocolo(int i)
        {
            return _protocolos[i];
        }

        public void SetProtocolo(int i, ProtocoloExp2 protocolo)
        {
            Protocolos[i].ActiveAnim = protocolo.ActiveAnim;
            Protocolos[i].ActiveIllum = protocolo.ActiveIllum;
            Protocolos[i].AutoAnim = protocolo.AutoAnim;
            Protocolos[i].CiclosEntrePulso = protocolo.CiclosEntrePulso;
            Protocolos[i].CyclesNextProtocol = protocolo.CyclesNextProtocol;
            Protocolos[i].EnNegro = protocolo.EnNegro;
            Protocolos[i].ExtraWaitingTime = protocolo.ExtraWaitingTime;
            Protocolos[i].Invertir = protocolo.Invertir;
            Protocolos[i].IsActive = protocolo.IsActive;
            Protocolos[i].PrioridadCiclos = protocolo.PrioridadCiclos;
            Protocolos[i].TimeNextProtocol = protocolo.TimeNextProtocol;
            Protocolos[i].TimeToEndAnimation = protocolo.TimeToEndAnimation;
            Protocolos[i].TimeToShowTarget = protocolo.TimeToShowTarget;
            Protocolos[i].TimeToStartAnimation = protocolo.TimeToStartAnimation;
            Protocolos[i].DistanceBwnTargets = protocolo.DistanceBwnTargets;
            Protocolos[i].ShouldLightenOnTouch = protocolo.ShouldLightenOnTouch;
        }

        protected override void PackData()
        {
            FBuffer[0] = Started ? 1 : 0;
            FBuffer[1] = Random ? 1 : 0;
            FBuffer[2] = ResetSignal ? 1.0f : 0.0f;

            for (int i = 0; i < NumberOfProtocols; i++)
            {
                int indice = (i*ValsPerProtocol) + 3;
                FBuffer[indice + 0] = _protocolos[i].Invertir ? 1 : 0;
                FBuffer[indice + 1] = _protocolos[i].IsActive ? 1 : 0;
                FBuffer[indice + 2] = _protocolos[i].EnNegro ? 1 : 0;
                FBuffer[indice + 3] = _protocolos[i].CiclosEntrePulso;
                FBuffer[indice + 4] = _protocolos[i].PrioridadCiclos ? 1 : 0;
                FBuffer[indice + 5] = _protocolos[i].TimeNextProtocol;
                FBuffer[indice + 6] = _protocolos[i].CyclesNextProtocol;
                FBuffer[indice + 7] = (float) _protocolos[i].ActiveAnim;
                FBuffer[indice + 8] = (float) _protocolos[i].ActiveIllum;
                FBuffer[indice + 9] = _protocolos[i].AutoAnim ? 1 : 0;
                FBuffer[indice + 10] = _protocolos[i].TimeToShowTarget;
                FBuffer[indice + 11] = _protocolos[i].TimeToStartAnimation;
                FBuffer[indice + 12] = _protocolos[i].TimeToEndAnimation;
                FBuffer[indice + 13] = _protocolos[i].ExtraWaitingTime;
                FBuffer[indice + 14] = _protocolos[i].DistanceBwnTargets;
                FBuffer[indice + 15] = _protocolos[i].ShouldLightenOnTouch ? 1:0;
                FBuffer[indice + 16] = _protocolos[i].TimeToLightenTarget;
            }
        }
    }
}