using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneDirectory.Contracts;
using PhoneDirectory.Readers;

namespace PhoneDirectory
{
    class PhonebookFileReader : FileReader, IPhoneBookReader
    {
        public string FilePath { get; private set; }

        public PhonebookFileReader(string filePath):base(filePath)
        {
            this.FilePath = filePath;
        }

        public List<IEntity> ReadRecords()
        {
            List<IEntity> persons = new List<IEntity>();            

            using (this.reader)
            {
                string text = this.reader.ReadToEnd();

                string[] lines = text.Split(new char[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    IEntity entity = CreatePerson(line);

                    if (entity != null)
                    {
                        persons.Add(entity);
                    }
                }

                this.reader.Close();
                return persons;
            }            
        }

        public IEntity CreatePerson(string personLine)
        {
            string[] personInfo = personLine.Split('|');

            string name = personInfo[0].Trim();
            string city = personInfo[1].Trim();
            string phone = personInfo[2].Trim();

            IEntity entity = new IEntity(name, city, phone);
            return entity;
        }
    }
}
