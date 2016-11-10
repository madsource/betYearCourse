using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<int,string> students = new Dictionary<int, string>();

            //students.Add(5, "Eli");
            //students.Add(6, "Gosho");
            //students.Add(7, "Stamat");

            //if (students.ContainsKey(27))
            //{
            //    Console.WriteLine(students[27]);
            //}

            //KeyValuePair<int, int> ids = new KeyValuePair<int, int>(5, 6); // item of Dictionary e.g. student in foreach

            //foreach (var student in students)
            //{
            //    Console.WriteLine(student.Value);
            //}

            //Console.WriteLine("Enter big text: ");
            //string text = Console.ReadLine();

            //Read write from file
            string filePathSource = "../../words.txt";

            if (!File.Exists(filePathSource))
            {
                Console.WriteLine("Source file words.txt does not exist!");
            }
            else
            {
                StreamReader reader = new StreamReader(filePathSource);
                StreamWriter writer = new StreamWriter("../../wordsCount.txt");
                string text;

                using (reader)
                {
                    text = reader.ReadToEnd();
                }

                char[] separators = { ',', ' ', '.', '!', '?', ';', '\r', '\n', '\t' };

                string[] textArray = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();

                foreach (var s in textArray)
                {
                    if (!wordsDictionary.ContainsKey(s))
                    {
                        wordsDictionary.Add(s, 1);
                    }
                    else
                    {
                        wordsDictionary[s]++;
                    }
                }


                using (writer)
                {
                    foreach (var i in wordsDictionary.OrderByDescending(x => x.Value))
                    {
                        //Console.WriteLine($"{i.Key} - {i.Value} times.");
                        writer.WriteLine($"{i.Key} - {i.Value} times.");
                    }

                    Console.WriteLine("File: wordsCount.txt is created!");
                }
            }
        }
    }
}
