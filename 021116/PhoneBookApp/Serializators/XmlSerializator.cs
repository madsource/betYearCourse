using PhoneBookApp.Contracts;
using PhoneBookApp.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PhoneBookApp
{
    public class XmlSerializator<T> : ISerializator<T>
    {
   
        public void Serialize(IDisposable writer, T obj)
        {            
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            //XmlWriter xmlWriter = XmlWriter.Create("../../xmlBook.xml");

            using (writer)
            {
                serializer.Serialize((XmlWriter)writer, obj);
                //writer.WriteLine(string.Format($"Serialized on: {DateTime.Now}"));
            }
            
        }

        public T Deserialize(IDisposable reader)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (reader)
            {
                return (T)deserializer.Deserialize((XmlReader)reader);
            }
        }     
    }
}
