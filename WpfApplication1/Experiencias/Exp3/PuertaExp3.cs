using System;
using System.Runtime.Serialization;
using System.Windows.Data;

namespace WpfApplication1.Experiencias
{
    [Serializable]
    public class PuertaExp3 : ISerializable
    {
        #region DoorState enum

        [Serializable]
        public enum DoorState
        {
            Abierta = 0,
            Cerrada = 1,
            Auto = 2
        } ;

        #endregion

        private DoorState _estadoPuerta;
        private float _tamanoPuerta;

        public PuertaExp3()
        {
            _estadoPuerta = DoorState.Abierta;
            TamanoPuerta = 1;
        }

        public PuertaExp3(SerializationInfo info, StreamingContext ctxt)
        {
            //_estadoPuerta = DoorState.Abierta;
            EstadoPuerta = (DoorState)info.GetValue("EstadoPuerta", typeof(DoorState));
            TamanoPuerta = (float)info.GetValue("TamanoPuerta", typeof(float));
        }


        public DoorState EstadoPuerta
        {
            get { return _estadoPuerta; }
            set { _estadoPuerta = value; }
        }

        public float TamanoPuerta
        {
            get { return _tamanoPuerta; }
            set { _tamanoPuerta = value; }
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EstadoPuerta", EstadoPuerta);
            info.AddValue("TamanoPuerta", TamanoPuerta);
        }

        #endregion
    }
}

public class EnumToBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return value.Equals(parameter);
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return value.Equals(true) ? parameter : Binding.DoNothing;
    }
}