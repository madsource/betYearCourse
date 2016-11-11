using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PhoneBookApp
{
    public class JsonSerializator : Serializator
    {
        public JsonSerializator(string filePath) : base(filePath)
        {
        }

        public override void Serialize(List<Person> person)
        {
            StreamWriter writer = new StreamWriter(this.FilePath);

            using (writer)
            {
                writer.WriteLine(JsonConvert.SerializeObject(person));
            }
        }

        public override List<Person> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject(json) as List<Person>;
        }
    }
}