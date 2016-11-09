using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("../../text.txt", true, Encoding.UTF8);

            //writer.Close(); -- using instead! Self closing.

            using (writer)
            {
                writer.WriteLine("Лол!");
                writer.WriteLine("Hey! Yey!");
            }

            StreamReader reader = new StreamReader("../../text.txt", Encoding.UTF8);

            using (reader)
            {
                //string text = reader.ReadToEnd();
                //Console.WriteLine(text);

                //or 

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }


            using (BinaryWriter writerBin = new BinaryWriter(File.Open("../../binary.bin", FileMode.Create)))
            {
                writerBin.Write(28);
            }

            using (BinaryReader readerBin = new BinaryReader(File.Open("../../binary.bin", FileMode.Open)))
            {
                int integerValue = readerBin.ReadInt32();
                Console.WriteLine(integerValue);
            }
        }
    }
}
