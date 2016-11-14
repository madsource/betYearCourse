using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Command
{
    public class FindCommand: PhonebookCommand
    {
        public FindCommand(string[] arguments) : base(arguments)
        {
           
        }

        public IEntity FindEntity(string name, PhoneBook<IEntity> book)
        {
            return book.EntitiesList.Find(p => p.Name.ToLower() == name.ToLower());
        }

        public IEntity FindEntity(string name, string city, PhoneBook<IEntity> book)
        {
            return book.EntitiesList.Find(p => p.Name.ToLower() == name.ToLower() && p.CityName.ToLower() == city.ToLower());
        }

        public List<IEntity> FindAllEntities(string name, PhoneBook<IEntity> book)
        {
            return book.EntitiesList.FindAll(p => p.Name.ToLower() == name.ToLower()).ToList();
        }
    }
}
