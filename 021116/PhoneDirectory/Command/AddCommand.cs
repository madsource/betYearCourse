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

        public void Add(IEntity item, PhoneBook book)
        {
            if (PhoneBook.TakenPhonesSet.Contains(item.PhoneNumber))
            {
                Console.WriteLine($"IEntity with phone number: {item.PhoneNumber} already exists in {book}");
            }
            else
            {
                book.EntitiesList.Add(item);
                PhoneBook.TakenPhonesSet.Add(item.PhoneNumber);
            }
        }

        public void AddToFile(IEntity item, FileWriter writer, PhoneBook book)
        {
            if (PhoneBook.TakenPhonesSet.Contains(item.PhoneNumber))
            {
                Console.WriteLine($"IEntity with phone number: {item.PhoneNumber} already exists in {book}");
            }
            else
            {
                book.EntitiesList.Add(item);
                PhoneBook.TakenPhonesSet.Add(item.PhoneNumber);

                using (writer)
                {
                    writer.WriteLine(String.Format($"{item.Name} | {item.CityName} | {item.PhoneNumber}"));
                }
            }
        }
    }
}
