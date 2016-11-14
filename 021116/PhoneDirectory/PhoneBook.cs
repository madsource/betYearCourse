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
    public class PhoneBook<T> where T: IEntity
    {
        public static HashSet<T> TakenPhonesSet;
        public string Name { get; set; }
        public List<T> EntitiesList { get; set; }
        public int Count
        {
            get { return this.EntitiesList.Count; }
        }

        public PhoneBook(string name)
        {
            EntitiesList = new List<T>();

            PhonebookEntityComparer comparer = new PhonebookEntityComparer();
            TakenPhonesSet = new HashSet<T>(comparer);
            this.Name = name;
        }

        public T this[int index]
        {
            get { return this.GetElementAt(index); }
            set { this.SetElementAt(index, value); }
        }

        private void SetElementAt(int index, T value)
        {
            this.EntitiesList[index] = value;
        }

        private T GetElementAt(int index)
        {
            return this.EntitiesList[index];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.EntitiesList.Select((t, i) => EntitiesList[i]).GetEnumerator();
        }
        
        public void Clear()
        {
            this.EntitiesList.Clear();
        }

        public bool Contains(T item)
        {
            return this.EntitiesList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            return this.EntitiesList.Remove(item);
        }

        public override string ToString()
        {
            return String.Format(this.Name);
        }

    }
}
