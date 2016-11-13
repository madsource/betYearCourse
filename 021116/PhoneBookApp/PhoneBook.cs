using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using PhoneBookApp.Contracts;
using PhoneBookApp;

namespace PhoneBookApp
{
    public class PhoneBook : ICollection<Person>
    {
        private static HashSet<string> TakenPhonesSet;
        public string Name { get; set; }
        public List<Person> PersonsList { get; set; }
        public int Count
        {
            get { return this.PersonsList.Count; }
        }
        public bool IsReadOnly { get; }

        public PhoneBook(string name)
        {
            PersonsList = new List<Person>();
            TakenPhonesSet = new HashSet<string>();
            this.Name = name;
        }

        public Person this[int index]
        {
            get { return this.GetElementAt(index); }
            set { this.SetElementAt(index, value); }
        }

        private void SetElementAt(int index, Person value)
        {
            this.PersonsList[index] = value;
        }

        private Person GetElementAt(int index)
        {
            return this.PersonsList[index];
        }

        public Person FindPerson(string name)
        {
            return this.PersonsList.Find(p => p.Name.ToLower() == name.ToLower());
        }

        public Person FindPerson(string name, string city)
        {
            return this.PersonsList.Find(p => p.Name.ToLower() == name.ToLower() && p.CityName.ToLower() == city.ToLower());
        }

        public List<Person> FindAllPersons(string name)
        {
            return this.PersonsList.FindAll(p => p.Name.ToLower() == name.ToLower()).ToList();
        }

        public void Serialize(ISerializator<PhoneBook> serializer, IWriter writer)
        {
            serializer.Serialize(writer as FileWriter, this);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int i = 0; i < this.PersonsList.Count; i++)
            {
                yield return PersonsList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Person item)
        {
            if (TakenPhonesSet.Contains(item.PhoneNumber))
            {
                Console.WriteLine($"Person with phone number: {item.PhoneNumber} already exists in {this}");
            }
            else
            {
                this.PersonsList.Add(item);
                TakenPhonesSet.Add(item.PhoneNumber);                
            }
        }

        public void AddToFile(Person item, FileWriter writer)
        {
            if (TakenPhonesSet.Contains(item.PhoneNumber))
            {
                Console.WriteLine($"Person with phone number: {item.PhoneNumber} already exists in {this}");
            }
            else
            {
                this.PersonsList.Add(item);
                TakenPhonesSet.Add(item.PhoneNumber);

                using (writer)
                {
                    writer.WriteLine(String.Format($"{item.Name} | {item.CityName} | {item.PhoneNumber}"));
                }
            }
        }

        public void Clear()
        {
            this.PersonsList.Clear();
        }

        public bool Contains(Person item)
        {
            return this.PersonsList.Contains(item);
        }

        public void CopyTo(Person[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Person item)
        {
            return this.PersonsList.Remove(item);
        }

        public override string ToString()
        {
            return String.Format(this.Name);
        }

    }
}
