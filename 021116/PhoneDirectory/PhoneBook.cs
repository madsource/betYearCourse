using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using PhoneDirectory;
using PhoneDirectory.Contracts;

namespace PhoneDirectory
{
    public class PhoneBook
    {
        public static HashSet<string> TakenPhonesSet;
        public string Name { get; set; }
        public List<IEntity> EntitiesList { get; set; }
        public int Count
        {
            get { return this.EntitiesList.Count; }
        }
        public bool IsReadOnly { get; }

        public PhoneBook(string name)
        {
            EntitiesList = new List<IEntity>();
            TakenPhonesSet = new HashSet<string>();
            this.Name = name;
        }

        public IEntity this[int index]
        {
            get { return this.GetElementAt(index); }
            set { this.SetElementAt(index, value); }
        }

        private void SetElementAt(int index, IEntity value)
        {
            this.EntitiesList[index] = value;
        }

        private IEntity GetElementAt(int index)
        {
            return this.EntitiesList[index];
        }

        //public IEntity FindPerson(string name)
        //{
        //    return this.EntitiesList.Find(p => p.Name.ToLower() == name.ToLower());
        //}

        //public IEntity FindPerson(string name, string city)
        //{
        //    return this.EntitiesList.Find(p => p.Name.ToLower() == name.ToLower() && p.CityName.ToLower() == city.ToLower());
        //}

        //public List<IEntity> FindAllPersons(string name)
        //{
        //    return this.EntitiesList.FindAll(p => p.Name.ToLower() == name.ToLower()).ToList();
        //}

        //public void Serialize(ISerializator<PhoneBook> serializer, IWriter writer)
        //{
        //    serializer.Serialize(writer as FileWriter, this);
        //}

        public IEnumerator<IEntity> GetEnumerator()
        {
            return this.EntitiesList.Select((t, i) => EntitiesList[i]).GetEnumerator();
        }

        //public void Add(IEntity item)
        //{
        //    if (TakenPhonesSet.Contains(item.PhoneNumber))
        //    {
        //        Console.WriteLine($"IEntity with phone number: {item.PhoneNumber} already exists in {this}");
        //    }
        //    else
        //    {
        //        this.EntitiesList.Add(item);
        //        TakenPhonesSet.Add(item.PhoneNumber);                
        //    }
        //}

        //public void AddToFile(IEntity item, FileWriter writer)
        //{
        //    if (TakenPhonesSet.Contains(item.PhoneNumber))
        //    {
        //        Console.WriteLine($"IEntity with phone number: {item.PhoneNumber} already exists in {this}");
        //    }
        //    else
        //    {
        //        this.EntitiesList.Add(item);
        //        TakenPhonesSet.Add(item.PhoneNumber);

        //        using (writer)
        //        {
        //            writer.WriteLine(String.Format($"{item.Name} | {item.CityName} | {item.PhoneNumber}"));
        //        }
        //    }
        //}

        public void Clear()
        {
            this.EntitiesList.Clear();
        }

        public bool Contains(IEntity item)
        {
            return this.EntitiesList.Contains(item);
        }

        public void CopyTo(IEntity[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IEntity item)
        {
            return this.EntitiesList.Remove(item);
        }

        public override string ToString()
        {
            return String.Format(this.Name);
        }

    }
}
