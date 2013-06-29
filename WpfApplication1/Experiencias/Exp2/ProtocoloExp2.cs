using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace WpfApplication1.Experiencias.Exp2
{
    [Serializable]
    public class ProtocoloExp2 : ISerializable, IDataErrorInfo, INotifyPropertyChanged
    {
        #region AnimOptions enum

        public enum AnimOptions
        {
            DerechoRecto = 0,
            DerechoOblicuo = 1,
            IzquierdoRecto = 2,
            IzquierdoOblicuo = 3
        } ;

        #endregion

        #region IllumOptions enum

        public enum IllumOptions
        {
            Random = 0,
            LeftPanel = 1,
            RightPanel = 2
        } ;

        #endregion

        private AnimOptions _activeAnim;
        private IllumOptions _activeIllum;
        private bool _autoAnim;
        private int _ciclosEntrePulso;
        private int _cyclesNextProtocol;
        private float _distanceBwnTargets;
        private bool _enNegro;
        private float _extraWaitingTime;
        private bool _invertir;
        private bool _isActive;
        private bool _prioridadCiclos;
        private float _timeNextProtocol;
        private float _timeToEndAnimation;
        private float _timeToShowTarget;
        private float _timeToStartAnimation;

        public ProtocoloExp2(int idx)
        {
            IndiceProtocolo = idx;
            IndiceVisual = idx + 1;
        }

        public int IndiceProtocolo { get; set; }

        public int IndiceVisual { get; set; }


        public bool Invertir
        {
            get { return _invertir; }
            set
            {
                if (value != _invertir)
                {
                    _invertir = value;
                    NotifyPropertyChanged("Invertir");
                }
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (value != _isActive)
                {
                    _isActive = value;
                    NotifyPropertyChanged("IsActive");
                }
            }
        }

        public bool EnNegro
        {
            get { return _enNegro; }
            set
            {
                if (value != _enNegro)
                {
                    _enNegro = value;
                    NotifyPropertyChanged("EnNegro");
                }
            }
        }

        public bool AutoAnim
        {
            get { return _autoAnim; }
            set
            {
                if (value != _autoAnim)
                {
                    _autoAnim = value;
                    NotifyPropertyChanged("AutoAnim");
                }
                _autoAnim = value;
            }
        }

        public AnimOptions ActiveAnim
        {
            get { return _activeAnim; }
            set
            {
                if (value != _activeAnim)
                {
                    _activeAnim = value;
                    NotifyPropertyChanged("ActiveAnim");
                }
            }
        }

        public IllumOptions ActiveIllum
        {
            get { return _activeIllum; }
            set
            {
                if (value != _activeIllum)
                {
                    _activeIllum = value;
                    NotifyPropertyChanged("ActiveIllum");
                }
            }
        }

        //Un ciclo es el transcurso del tiempo indicado abajo

        public int CyclesNextProtocol
        {
            get { return _cyclesNextProtocol; }
            set
            {
                if (value != _cyclesNextProtocol)
                {
                    _cyclesNextProtocol = value;
                    NotifyPropertyChanged("CyclesNextProtocol");
                }
            }
        }

        public float TimeNextProtocol
        {
            get { return _timeNextProtocol; }
            set
            {
                if (value != _timeNextProtocol)
                {
                    _timeNextProtocol = value;
                    NotifyPropertyChanged("TimeNextProtocol");
                }
            }
        }

        public bool PrioridadCiclos
        {
            get { return _prioridadCiclos; }
            set
            {
                if (value != _prioridadCiclos)
                {
                    _prioridadCiclos = value;
                    NotifyPropertyChanged("PrioridadCiclos");
                }
            }
        }

        public int CiclosEntrePulso
        {
            get { return _ciclosEntrePulso; }
            set
            {
                if (value != _ciclosEntrePulso)
                {
                    _ciclosEntrePulso = value;
                    NotifyPropertyChanged("CiclosEntrePulso");
                }
            }
        }

        /*VARIABLES TEMPORALES*/

        /**
         * 
         * 
         *  TimeToShowTarget
         *  |--------------------------|
         *  
         *  TimeToStartAnimation
         *  |--------------------------|------------------------|
         *  
         *  TimeToEndAnimation
         *  |--------------------------|------------------------|----------------------|
         *  
         *  ExtraWaitingTime
         *  |--------------------------|------------------------|----------------------|--------------------|
         * 
         * 
         */

        public float TimeToShowTarget
        {
            get { return _timeToShowTarget; }
            set
            {
                if (value != _timeToShowTarget)
                {
                    _timeToShowTarget = value;
                    NotifyPropertyChanged("TimeToShowTarget");
                }
            }
        }

        public float TimeToStartAnimation
        {
            get { return _timeToStartAnimation; }
            set
            {
                if (value != _timeToStartAnimation)
                {
                    _timeToStartAnimation = value;
                    NotifyPropertyChanged("TimeToStartAnimation");
                }
            }
        }

        public float TimeToEndAnimation
        {
            get { return _timeToEndAnimation; }
            set
            {
                if (value != _timeToEndAnimation)
                {
                    _timeToEndAnimation = value;
                    NotifyPropertyChanged("TimeToEndAnimation");
                }
            }
        }

        public float ExtraWaitingTime
        {
            get { return _extraWaitingTime; }
            set
            {
                if (value != _extraWaitingTime)
                {
                    _extraWaitingTime = value;
                    NotifyPropertyChanged("ExtraWaitingTime");
                }
            }
        }

        public float DistanceBwnTargets
        {
            get { return _distanceBwnTargets; }
            set
            {
                if (value != _distanceBwnTargets)
                {
                    _distanceBwnTargets = value;
                    NotifyPropertyChanged("DistanceBwnTargets");
                }
            }
        }

        #region ISerializable members

        public ProtocoloExp2(SerializationInfo info, StreamingContext ctxt)
        {
            IndiceProtocolo = (int) info.GetValue("IndiceProtocolo", typeof (int));
            IndiceVisual = (int) info.GetValue("IndiceVisual", typeof (int));
            Invertir = (bool) info.GetValue("Invertir", typeof (bool));
            EnNegro = (bool) info.GetValue("EnNegro", typeof (bool));
            IsActive = (bool) info.GetValue("IsActive", typeof (bool));

            ActiveAnim = (AnimOptions) info.GetValue("ActiveAnim", typeof (AnimOptions));
            ActiveIllum = (IllumOptions) info.GetValue("ActiveIllum", typeof (IllumOptions));
            AutoAnim = (bool) info.GetValue("AutoAnim", typeof (bool));

            CiclosEntrePulso = (int) info.GetValue("CiclosEntrePulso", typeof (int));
            CyclesNextProtocol = (int) info.GetValue("CyclesNextProtocol", typeof (int));
            TimeNextProtocol = (float) info.GetValue("TimeNextProtocol", typeof (float));
            PrioridadCiclos = (bool) info.GetValue("PrioridadCiclos", typeof (bool));

            TimeToShowTarget = (float) info.GetValue("TimeToShowTarget", typeof (float));
            TimeToStartAnimation = (float) info.GetValue("TimeToStartAnimation", typeof (float));
            TimeToEndAnimation = (float) info.GetValue("TimeToEndAnimation", typeof (float));
            ExtraWaitingTime = (float) info.GetValue("ExtraWaitingTime", typeof (float));

            DistanceBwnTargets = (float) info.GetValue("DistanceBwnTargets", typeof (float));
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IndiceProtocolo", IndiceProtocolo);
            info.AddValue("IndiceVisual", IndiceVisual);
            info.AddValue("Invertir", Invertir);
            info.AddValue("EnNegro", EnNegro);
            info.AddValue("IsActive", IsActive);

            info.AddValue("ActiveAnim", ActiveAnim);
            info.AddValue("ActiveIllum", ActiveIllum);
            info.AddValue("AutoAnim", AutoAnim);


            info.AddValue("CiclosEntrePulso", CiclosEntrePulso);
            info.AddValue("CyclesNextProtocol", CyclesNextProtocol);
            info.AddValue("TimeNextProtocol", TimeNextProtocol);
            info.AddValue("PrioridadCiclos", PrioridadCiclos);


            info.AddValue("TimeToShowTarget", TimeToShowTarget);
            info.AddValue("TimeToStartAnimation", TimeToStartAnimation);
            info.AddValue("TimeToEndAnimation", TimeToEndAnimation);
            info.AddValue("ExtraWaitingTime", ExtraWaitingTime);

            info.AddValue("DistanceBwnTargets", DistanceBwnTargets);
        }

        #endregion

        #region IDataErrorInfo members

        public string this[string columnName]
        {
            get
            {
                string result = null;

                if (columnName == "TimeToStartAnimation")
                {
                    if (TimeToStartAnimation < TimeToShowTarget)
                        result = "El tiempo de inicio de animación debe ser posterior al de aparición de la diana.";
                    else if (TimeToStartAnimation >= TimeToEndAnimation || TimeToStartAnimation >= ExtraWaitingTime)
                        result =
                            "El tiempo de inicio de animación debe ser menor que el de fin de animación y que la duración de ciclo.";
                }
                else if (columnName == "TimeToEndAnimation")
                {
                    if (TimeToEndAnimation <= TimeToStartAnimation)
                        result = "El tiempo de final de animación debe ser mayor al de inicio de animación.";
                    else if (TimeToEndAnimation > ExtraWaitingTime)
                        result = "El tiempo de final de animación debe ser menor o igual a la duración de ciclo";
                }
                else if (columnName == "ExtraWaitingTime")
                {
                    if (AutoAnim && (ExtraWaitingTime < TimeToEndAnimation))
                        result = "El tiempo total de ciclo debe ser mayor al de finalización de la animación.";
                    else if (!AutoAnim && (ExtraWaitingTime <= TimeToShowTarget))
                        result = "El tiempo total de ciclo debe ser superior al de aparición de la diana.";
                }
                else if (columnName == "TimeToShowTarget")
                {
                    if (TimeToShowTarget > TimeToStartAnimation || TimeToShowTarget >= TimeToEndAnimation ||
                        TimeToShowTarget > ExtraWaitingTime)
                        result =
                            "El tiempo de aparición de la diana debe ser inferior al de inicio de animación, final de animación y duración total de ciclo.";
                }

                return result;
            }
        }

        public string Error
        {
            get { return null; }
        }

        #endregion

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