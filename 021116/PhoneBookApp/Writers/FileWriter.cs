using PhoneBookApp.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class FileWriter : TextWriter, IWriter, IDisposable
    {
        private StreamWriter writer;

        public FileWriter(string filePath)
        {            
            writer = new StreamWriter(filePath, true, Encoding.UTF8);
        }

        public override Encoding Encoding
        {
            get
            {
                return this.writer.Encoding;
            }
        }

        public void Dispose()
        {
            this.writer.Close();
        }

        public void Write(string text)
        {
            this.writer.Write(text);
        }

        public void WriteLine(string text)
        {
            this.writer.WriteLine(text);
        }
    }
}
