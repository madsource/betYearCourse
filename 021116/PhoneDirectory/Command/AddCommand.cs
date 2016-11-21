using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Command
{
    public class AddCommand: PhonebookCommand
    {
        public AddCommand(string[] arguments) : base(arguments)
        {
        }

        public void Add(IEntity item, PhoneBook<IEntity> book)
        {
            if (PhoneBook<IEntity>.TakenPhonesSet.Contains(item))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{item.Name} with phone number: {item.PhoneNumber} already exists in {book}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                book.EntitiesList.Add(item);
                PhoneBook<IEntity>.TakenPhonesSet.Add(item);
            }
        }

        public void AddToFile(IEntity item, FileWriter writer, PhoneBook<IEntity> book)
        {
            if (PhoneBook<IEntity>.TakenPhonesSet.Contains(item))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{item.Name} with phone number: {item.PhoneNumber} already exists in {book}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                book.EntitiesList.Add(item);
                PhoneBook<IEntity>.TakenPhonesSet.Add(item);

                using (writer)
                {
                    writer.WriteLine(String.Format($"{item.Name} | {item.CityName} | {item.PhoneNumber}"));
                }
            }
        }
    }
}
