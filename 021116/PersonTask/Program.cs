using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Constructors testing
            //Console.Write("Give me name: ");
            //string personName = Console.ReadLine();
            //Console.Write("Give me age: ");
            //int personAge;
            //int.TryParse(Console.ReadLine(), out personAge);

            //Person p1 = new Person();
            //Person p2 = new Person(personName);
            //Person p3 = new Person(personName, personAge);

            //Console.Write(p1.Name + " ");
            //Console.Write(p1.Age + "\n");

            //Console.Write(p2.Name + " ");
            //Console.Write(p2.Age + "\n");

            //Console.Write(p3.Name + " ");
            //Console.Write(p3.Age + "\n\n");

            // Object sorting by length of name, excluding age under 18
            List<Person> personsList = new List<Person>();

            Console.WriteLine("Please, enter people by name//age and \"quit\" to quit.");
            while(true)
            {
                string input = Console.ReadLine();
                if (input == "quit") break;

                string[] personsDetails = input.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
                string personsName = personsDetails[0];
                int personsAge = int.Parse(personsDetails[1]);

                if (personsAge >= 18 )
                {
                    Person person = new Person(personsName, personsAge);
                    personsList.Add(person);
                }
            }

            if(personsList.Count > 0)
            {
                List<Person> orderedList = personsList.OrderBy(p => p.Name.Length).ToList();
                foreach (var p in orderedList)
                {
                    Console.WriteLine($"{p.Name} - {p.Age}");
                }
            } else
            {
                Console.WriteLine("No persons in your list!");
            }
        }
    }
}
