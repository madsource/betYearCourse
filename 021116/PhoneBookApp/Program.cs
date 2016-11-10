using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (!File.Exists("../../phonebook.txt"))
            {
                Console.WriteLine("No file phonebook.txt found!");
            }
            else
            {
                PhonebookReader reader = new PhonebookReader("../../phonebook.txt");
                List<Person> contacts = reader.ReadRecords();

                foreach (var person in contacts)
                {
                    Console.WriteLine(person);
                    book.Add(person);
                }
            }
        }
    }
}
