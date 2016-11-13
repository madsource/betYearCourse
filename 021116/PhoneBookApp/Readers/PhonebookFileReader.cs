using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookApp.Contracts;
using PhoneBookApp.Readers;

namespace PhoneBookApp
{
    class PhonebookFileReader : FileReader, IPhoneBookReader
    {
        public string FilePath { get; private set; }

        public PhonebookFileReader(string filePath):base(filePath)
        {
            this.FilePath = filePath;
        }

        public List<Person> ReadRecords()
        {
            List<Person> persons = new List<Person>();            

            using (this.reader)
            {
                string text = this.reader.ReadToEnd();

                string[] lines = text.Split(new char[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    Person person = CreatePerson(line);

                    if (person != null)
                    {
                        persons.Add(person);
                    }
                }

                this.reader.Close();
                return persons;
            }            
        }

        public Person CreatePerson(string personLine)
        {
            string[] personInfo = personLine.Split('|');

            string name = personInfo[0].Trim();
            string city = personInfo[1].Trim();
            string phone = personInfo[2].Trim();

            Person person = new Person(name, city, phone);
            return person;
        }
    }
}
