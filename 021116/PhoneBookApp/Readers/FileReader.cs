using PhoneBookApp.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Readers
{
    public class FileReader : IReader, IDisposable
    {
        private StreamReader reader;

        public FileReader(string filePath)
        {
            if(File.Exists(filePath))
            {
                this.reader = new StreamReader(filePath);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void Dispose()
        {
            this.reader.Close();
        }

        public int Read()
        {
            return this.reader.Read();
        }

        public string ReadLine()
        {
            return this.reader.ReadLine();
        }

        public string ReadToEnd()
        {
            return this.reader.ReadToEnd();
        }
    }
}
