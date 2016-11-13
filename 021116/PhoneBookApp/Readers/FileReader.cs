using PhoneBookApp.Contracts;
using System;
using System.IO;
using System.Text;

namespace PhoneBookApp.Readers
{
    public class FileReader : TextReader, IReader, IDisposable
    {
        protected StreamReader reader;
     

        public FileReader(string filePath)
        {
            if(File.Exists(filePath))
            {
                this.reader = new StreamReader(filePath, Encoding.UTF8);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void Dispose()
        {
            this.reader.Close();
            base.Dispose();
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
