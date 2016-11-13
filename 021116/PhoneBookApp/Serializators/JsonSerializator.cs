using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PhoneBookApp;
using PhoneBookApp.Contracts;
using PhoneBookApp.Readers;
using System;

namespace PhoneBookApp
{
    public class JsonSerializator<T> : Serializator<T>
    {      
        public override void Serialize(IWriter writer, T obj)
        {
            if(writer is FileWriter)
            {
                using (writer as FileWriter)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(obj));
                    //writer.WriteLine(string.Format($"Serialized on: {DateTime.Now}"));
                }
            } else
            {
                writer.WriteLine(JsonConvert.SerializeObject(obj));
                //writer.WriteLine(string.Format($"Serialized on: {DateTime.Now}"));
            }
            
        }

        public override T Deserialize(IReader reader)
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