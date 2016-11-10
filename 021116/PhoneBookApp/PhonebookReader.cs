using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookApp.Contracts;

namespace PhoneBookApp
{
    class PhonebookReader : IPhoneBookReader
    {
        private StreamReader _reader;
        private int nextLine;

        public string FilePath { get; set; }

        public PhonebookReader(string filePath)
        {
            this._reader = new StreamReader(filePath);
            this.nextLine = 0;
        }

        public List<Person> ReadRecords()
        {
            List<Person> persons = new List<Person>();
            string text;

            using (_reader)
            {
                text = _reader.ReadToEnd();

                string[] lines = text.Split(new char[] {'\n', '\r'});

                foreach (var line in lines)
                {
                    Person person = CreatePerson(line);

                    if (person != null)
                    {
                        persons.Add(person);
                    }
                }
            }

            return persons;
        }

        public Person CreatePerson(string personLine)
        {
            throw new NotImplementedException();
        }
    }
}
