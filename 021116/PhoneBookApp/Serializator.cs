using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using PhoneBookApp.Contracts;

namespace PhoneBookApp
{
    public abstract class Serializator : ISerializator<List<Person>>
    {

        public string FilePath { get; set; }

        public Serializator(string filePath)
        {
            this.FilePath = filePath;
        }

        public abstract void Serialize(List<Person> person);

        public abstract List<Person> Deserialize(string json);
    }
}
