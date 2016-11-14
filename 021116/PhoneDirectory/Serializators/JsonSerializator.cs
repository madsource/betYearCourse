using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PhoneDirectory;
using System;
using PhoneDirectory.Contracts;
using PhoneDirectory.Readers;

namespace PhoneDirectory
{
    public class JsonSerializator<T> : ISerializator<T>
    {      
        public void Serialize(IDisposable writer, T obj)
        {
            if(writer is FileWriter)
            {
                using (writer)
                {
                    ((FileWriter)writer).WriteLine(JsonConvert.SerializeObject(obj));
                    //writer.WriteLine(string.Format($"Serialized on: {DateTime.Now}"));
                }
            } else
            {
                ((FileWriter)writer).WriteLine(JsonConvert.SerializeObject(obj));
                //writer.WriteLine(string.Format($"Serialized on: {DateTime.Now}"));
            }
            
        }

        public T Deserialize(IDisposable reader)
        {
            string json;
            using (reader as FileReader)
            {
                json = ((FileReader)reader).ReadLine();                
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}