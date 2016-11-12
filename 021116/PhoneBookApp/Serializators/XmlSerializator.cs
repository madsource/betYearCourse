using PhoneBookApp.Contracts;
using PhoneBookApp.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PhoneBookApp
{
    public class XmlSerializator<T> : Serializator<T>
    {
   
        public override void Serialize(IWriter writer, T obj)
        {            
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            using(writer as IDisposable)
            {
                serializer.Serialize((TextWriter)writer, obj);
                writer.WriteLine(string.Format($"Serialized on: {DateTime.Now}"));
            }
            
        }

        public override T Deserialize(IReader reader)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (reader as StreamReader)
            {
                return (T)deserializer.Deserialize(reader as StreamReader);
            }
        }     
    }
}
