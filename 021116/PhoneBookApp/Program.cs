using PhoneBookApp;
using PhoneBookApp.Contracts;
using PhoneBookApp.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PhoneBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook book = new PhoneBook("Mad book");

            //Person p1 = new Person("Ivan", "Sofia", "08884545566");
            //book.Add(p1);

            //Person p2 = new Person("Joro", "Plovdiv", "08884545566");
            //book.Add(p2);

            //Person p3 = new Person("Gosho", "Burgas", "087855552254");
            //book.Add(p3);

            //Person p4 = new Person("Iva", "Ruse", "078455224555");
            //book.Add(p4);

            //Person p5 = new Person("Krasi", "Sofia", "08884575566");
            //book.Add(p5);

            if (!File.Exists("../../book.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No file phonebook.txt found!");
            }
            else
            {
                PhonebookFileReader reader = new PhonebookFileReader("../../book.txt");

                List<Person> contacts;
                using (reader)
                {
                    contacts = reader.ReadRecords();
                }

                foreach (var person in contacts)
                {
                    Console.WriteLine(person);
                    book.Add(person);
                }

                PhonebookCommandFileReader commandReader = new PhonebookCommandFileReader("../../commands.txt");
                List<PhonebookCommand> commands = commandReader.GetCommands();

                foreach (var phonebookCommand in commands)
                {
                    Console.WriteLine($"\n\nCommand: {phonebookCommand.CommandType}:");
                    for (int i = 0; i < phonebookCommand.Arguments.Length; i++)
                    {
                        Console.WriteLine($"\n - argument{i}: {phonebookCommand.Arguments[i]}");
                    }

                    if (phonebookCommand.CommandType == Commands.Serialize)
                    {
                        string name = phonebookCommand.Arguments[0];
                        string fileName = phonebookCommand.Arguments[1];
                        string serializationType = phonebookCommand.Arguments[2];

                        IDisposable writer = null;
                        ISerializator<List<Person>> serializator;


                        switch (serializationType.ToLower())
                        {
                            case "json": serializator = new JsonSerializator<List<Person>>(); writer = new FileWriter(fileName); break;
                            case "xml": serializator = new XmlSerializator<List<Person>>(); writer = XmlWriter.Create(fileName); break;
                            default: serializator = new JsonSerializator<List<Person>>(); writer = new FileWriter(fileName);  break;
                        }


                        List<Person> personsFound = book.FindAllPersons(name);

                        if (personsFound.Count > 0)
                        {
                            using (writer)
                            {
                                serializator.Serialize(writer, personsFound);
                            }
                            IDisposable fileReader = null;

                            if(serializationType.ToLower() == "json")
                            {
                                fileReader = new FileReader(fileName);
                            } else
                            {
                                fileReader = XmlReader.Create(fileName);
                            }

                            List<Person> newList = serializator.Deserialize(fileReader);

                            foreach (var person in newList)
                            {

                                Console.WriteLine($"Deserialized:\n -- Name {person.Name}, city: {person.CityName}, phone: {person.PhoneNumber}");
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"No person with name \"{name}\" found!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                    }
                    else if (phonebookCommand.CommandType == Commands.add)
                    {
                        var writer = new FileWriter("../../book.txt");
                        using (writer)
                        {
                            book.AddToFile(
                            new Person(
                                phonebookCommand.Arguments[0].Trim(),
                                phonebookCommand.Arguments[1].Trim(),
                                phonebookCommand.Arguments[2].Trim()
                                ),
                            writer
                            );
                        }

                    }
                    else if (phonebookCommand.CommandType == Commands.Find)
                    {
                        Person person = null;

                        if (phonebookCommand.Arguments.Length == 2)
                        {
                            person = book.FindPerson(phonebookCommand.Arguments[0], phonebookCommand.Arguments[1]);
                        }
                        else
                        {
                            person = book.FindPerson(phonebookCommand.Arguments[0]);
                        }

                        if (person != null)
                        {
                            var consoleWriter = new ConsoleWriter();
                            Console.ForegroundColor = ConsoleColor.Green;
                            consoleWriter.WriteLine(String.Format($"{person.Id} : {person.Name}, {person.CityName}, {person.PhoneNumber}"));
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
    }
}
