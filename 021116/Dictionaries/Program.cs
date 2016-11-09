using System;
using System.Collections.Generic;
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

            Console.WriteLine("Enter big text: ");
            string text = Console.ReadLine();

            char[] separators = {',', ' ', '.', '!', '?', ';'};

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

            foreach (var i in wordsDictionary)
            {
                Console.WriteLine($"{i.Key} - {i.Value} times.");
            }
        }
    }
}
