using PhoneDirectory;
using PhoneDirectory.Contracts;
using PhoneDirectory.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PhoneDirectory.Command;

namespace PhoneDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook book = new PhoneBook("Mad book");
 
            if (!File.Exists("../../book.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No file phonebook.txt found!");
            }
            else
            {
                PhonebookFileReader reader = new PhonebookFileReader("../../book.txt");

                List<IEntity> contacts;
                using (reader)
                {
                    contacts = reader.ReadRecords();
                }

                foreach (var person in contacts)
                {
                    Console.WriteLine(person);
                    var addCommand = new AddCommand(new string[]
                    {
                        person.Name,
                        person.CityName,
                        person.PhoneNumber
                    });

                    addCommand.Add(person, book);
                }

                PhonebookCommandFileReader commandReader = new PhonebookCommandFileReader("../../commands.txt");
                List<PhonebookCommand> commands = commandReader.GetCommands();

                foreach (var phonebookCommand in commands)
                {
                    Console.WriteLine($"\n\nCommand: {phonebookCommand}:");
                    for (int i = 0; i < phonebookCommand.Arguments.Length; i++)
                    {
                        Console.WriteLine($"\n - argument{i}: {phonebookCommand.Arguments[i]}");
                    }

                    if (phonebookCommand is SerializeCommand)
                    {
                        string name = phonebookCommand.Arguments[0];
                        string fileName = phonebookCommand.Arguments[1];
                        string serializationType = phonebookCommand.Arguments[2];

                        IDisposable writer = null;
                        ISerializator<List<IEntity>> serializator;


                        switch (((SerializeCommand)phonebookCommand).SerializationType)
                        {
                            case "json": serializator = new JsonSerializator<List<IEntity>>(); writer = new FileWriter(fileName); break;
                            case "xml": serializator = new XmlSerializator<List<IEntity>>(); writer = XmlWriter.Create(fileName); break;
                            default: serializator = new JsonSerializator<List<IEntity>>(); writer = new FileWriter(fileName); break;
                        }

                        var findCommand = new FindCommand(new string[] { name });

                        List<IEntity> personsFound = findCommand.FindAllEntities(name, book);

                        ((SerializeCommand)phonebookCommand).SerializeEntities(serializator, personsFound, writer);

                        //if (personsFound.Count > 0)
                        //{
                        //    using (writer)
                        //    {
                        //        serializator.Serialize(writer, personsFound);
                        //    }
                        //    IDisposable fileReader = null;

                        //    if(serializationType.ToLower() == "json")
                        //    {
                        //        fileReader = new FileReader(fileName);
                        //    } else
                        //    {
                        //        fileReader = XmlReader.Create(fileName);
                        //    }

                        //    List<IEntity> newList = serializator.Deserialize(fileReader);

                        //    foreach (var person in newList)
                        //    {

                        //        Console.WriteLine($"Deserialized:\n -- Name {person.Name}, city: {person.CityName}, phone: {person.PhoneNumber}");
                        //    }

                        //}
                        //else
                        //{
                        //    Console.ForegroundColor = ConsoleColor.Red;
                        //    Console.WriteLine($"No person with name \"{name}\" found!");
                        //    Console.ForegroundColor = ConsoleColor.White;
                        // }


                    }
                    else if (phonebookCommand is AddCommand)
                    {
                        var writer = new FileWriter("../../book.txt");
                        using (writer)
                        {
                            var entity =
                            new IEntity(
                                phonebookCommand.Arguments[0].Trim(),
                                phonebookCommand.Arguments[1].Trim(),
                                phonebookCommand.Arguments[2].Trim()
                            );
                            ((AddCommand)phonebookCommand).AddToFile(entity, writer, book);
                        }

                    }
                    else if (phonebookCommand is FindCommand)
                    {
                        IEntity entity = null;

                        if (phonebookCommand.Arguments.Length == 2)
                        {
                            entity = (phonebookCommand as FindCommand).FindEntity(phonebookCommand.Arguments[0], phonebookCommand.Arguments[1], book);
                        }
                        else
                        {
                            entity = (phonebookCommand as FindCommand).FindEntity(phonebookCommand.Arguments[0], book);
                        }

                        if (entity != null)
                        {
                            var consoleWriter = new ConsoleWriter();
                            Console.ForegroundColor = ConsoleColor.Green;
                            consoleWriter.WriteLine(String.Format($"{entity.Id} : {entity.Name}, {entity.CityName}, {entity.PhoneNumber}"));
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
    }
}
