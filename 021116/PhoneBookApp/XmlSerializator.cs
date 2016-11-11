using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PhoneBookApp
{
    public class XmlSerializator : Serializator
    {
        public XmlSerializator(string filePath) : base(filePath)
        {
        }

        public override void Serialize(List<Person> person)
        {
            StreamWriter writer = new StreamWriter(this.FilePath);
            XmlSerializer xmlSerializer = new XmlSerializer(person.GetType());

            using (writer)
            {
                xmlSerializer.Serialize(writer, person);
            }
        }

        public override List<Person> Deserialize(string json)
        {
            throw new NotImplementedException();
        }
    }
}
