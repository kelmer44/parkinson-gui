using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using WpfApplication1.Experiencias.Exp1;
using WpfApplication1.Experiencias.Exp2;
using WpfApplication1.Experiencias.Exp3;

namespace WpfApplication1.Experiencias
{
    public class Serializer
    {
        public void SerializeXp1(string filename, Experiencia1 objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            var bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public void SerializeXp2(string filename, Experiencia2 objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            var bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public void SerializeXp3(string filename, Experiencia3 objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            var bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public Experiencia1 DeSerializeExp1(string filename)
        {
            Experiencia1 objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            var bFormatter = new BinaryFormatter();
            try{
            objectToSerialize = (Experiencia1)bFormatter.Deserialize(stream);
                }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar el archivo.");
                return null;
            }
            stream.Close();
            return objectToSerialize;
        }

        public Experiencia3 DeSerializeExp3(string filename)
        {
            Experiencia3 objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            var bFormatter = new BinaryFormatter();
            try{
                objectToSerialize = (Experiencia3)bFormatter.Deserialize(stream);
                }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar el archivo.");
                return null;
            }
            stream.Close();
            return objectToSerialize;
        }

        public Experiencia2 DeSerializeExp2(string filename)
        {
            Experiencia2 objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            var bFormatter = new BinaryFormatter();
            try
            {
                objectToSerialize = (Experiencia2)bFormatter.Deserialize(stream);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar el archivo.");
                return null;
            }
            stream.Close();
            return objectToSerialize;
        }
    }
}