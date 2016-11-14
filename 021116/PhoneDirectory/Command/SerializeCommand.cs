using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneDirectory.Contracts;
using System.Xml;

namespace PhoneDirectory.Command
{
    public class SerializeCommand: PhonebookCommand
    {

        public string Name { get; private set; }
        public string FileName { get; private set; }
        public string SerializationType { get; private set; }

        public SerializeCommand(string[] arguments) : base(arguments)
        {
            Name = this.Arguments[0];
            FileName = this.Arguments[1];
            SerializationType = this.Arguments[2].ToLower();
        }

        public void SerializeBook(ISerializator<PhoneBook<IEntity>> serializer, IWriter writer, PhoneBook<IEntity> book)
        {
            serializer.Serialize(writer as FileWriter, book);
        }

        public void SerializeEntities(ISerializator<List<IEntity>> serializator, List<IEntity> entities, IDisposable writer)
        {
            if (entities.Count > 0)
            {
                using (writer)
                {
                    serializator.Serialize(writer, entities);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No entity to serialize found!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
