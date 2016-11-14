using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneDirectory.Contracts;

namespace PhoneDirectory
{
    public class IEntity : Contracts.IEntity
    {
        private static int _nextId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string PhoneNumber { get; set; }

        public IEntity()
        {
            this.Id = _nextId++;
        }

        public IEntity(string name, string cityName, string phoneNumber):this()
        {
            this.Name = name;
            this.CityName = cityName;
            this.PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return String.Format($"#{this.Id} - Name : {this.Name}, city: {this.CityName}, phone: {this.PhoneNumber}");
        }
    }
}
