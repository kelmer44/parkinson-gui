using System;
using System.Runtime.Serialization;

namespace WpfApplication1.Experiencias.Exp1
{
    [Serializable]
    public class ProtocoloExp1 : ISerializable
    {
        public ProtocoloExp1(int idx)
        {
            IndiceProtocolo = idx;
            IndiceVisual = idx + 1;
        }

        public int IndiceProtocolo { get; set; }

        public int IndiceVisual { get; set; }

        public bool Invertir { get; set; }

        public bool ActivateSound { get; set; }

        public bool ActivateAnimation { get; set; }

        public bool SoundSync { get; set; }

        public float SoundFrequency { get; set; }

        public float PassiveFrequency { get; set; }

        public float PostPassiveFrequency { get; set; }

        public float ActiveFrequency { get; set; }

        public int AnimationBlending { get; set; }

        public int CyclesNextProtocol { get; set; }

        public float TimeNextProtocol { get; set; }

        public bool IsActive { get; set; }

        public int CiclosEntrePulso { get; set; }

        public bool PrioridadCiclos { get; set; }

        public bool EnNegro { get; set; }

        #region ISerializable Members


        public ProtocoloExp1(SerializationInfo info, StreamingContext ctxt)
        {
            IndiceProtocolo = (int)info.GetValue("IndiceProtocolo", typeof(int));
            IndiceVisual = (int)info.GetValue("IndiceVisual", typeof(int));
            Invertir = (bool)info.GetValue("Invertir", typeof(bool));
            ActivateSound = (bool)info.GetValue("ActivateSound", typeof(bool));
            ActivateAnimation = (bool)info.GetValue("ActivateAnimation", typeof(bool));
            SoundSync = (bool)info.GetValue("SoundSync", typeof(bool));
            SoundFrequency = (float)info.GetValue("SoundFrequency", typeof(float));
            PassiveFrequency = (float)info.GetValue("PassiveFrequency", typeof(float));
            PostPassiveFrequency = (float)info.GetValue("PostPassiveFrequency", typeof(float));
            ActiveFrequency = (float)info.GetValue("ActiveFrequency", typeof(float));
            AnimationBlending = (int)info.GetValue("AnimationBlending", typeof(int));
            CyclesNextProtocol = (int)info.GetValue("CyclesNextProtocol", typeof(int));
            TimeNextProtocol = (float)info.GetValue("TimeNextProtocol", typeof(float));
            IsActive = (bool)info.GetValue("IsActive", typeof(bool));
            CiclosEntrePulso = (int)info.GetValue("CiclosEntrePulso", typeof(int));
            PrioridadCiclos = (bool)info.GetValue("PrioridadCiclos", typeof(bool));
            EnNegro = (bool)info.GetValue("EnNegro", typeof(bool));
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IndiceProtocolo", IndiceProtocolo);
            info.AddValue("IndiceVisual", IndiceVisual);
            info.AddValue("Invertir", Invertir);
            info.AddValue("ActivateSound", ActivateSound);
            info.AddValue("ActivateAnimation", ActivateAnimation);
            info.AddValue("SoundSync", SoundSync);
            info.AddValue("SoundFrequency", SoundFrequency);
            info.AddValue("PassiveFrequency", PassiveFrequency);
            info.AddValue("PostPassiveFrequency", PostPassiveFrequency);
            info.AddValue("ActiveFrequency", ActiveFrequency);
            info.AddValue("AnimationBlending", AnimationBlending);
            info.AddValue("CyclesNextProtocol", CyclesNextProtocol);
            info.AddValue("TimeNextProtocol", TimeNextProtocol);
            info.AddValue("IsActive", IsActive);
            info.AddValue("CiclosEntrePulso", CiclosEntrePulso);
            info.AddValue("PrioridadCiclos", PrioridadCiclos);
            info.AddValue("EnNegro", EnNegro);
        }

        #endregion
    }
}