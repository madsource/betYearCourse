using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SortedSets
{
    class Program
    {
        static void Main(string[] args)
        {
            IComparer<char> comparer = new StudentComparer();
            SortedSet<char> alphabet = new SortedSet<char>(comparer);

            alphabet.Add('a');
            alphabet.Add('c');
            alphabet.Add('x');
            alphabet.Add('y');

            foreach (char c in alphabet)
            {
                Console.WriteLine(c);
            }

            SortedDictionary<char, string> alphabetDictionary = new SortedDictionary<char, string>(comparer);

            alphabetDictionary.Add('c', "car");
            alphabetDictionary.Add('x', "xray");
            alphabetDictionary.Add('b', "bus");
            alphabetDictionary.Add('z', "zorro");
            alphabetDictionary.Add('m', "me");

            foreach (var c in alphabetDictionary)
            {
                Console.WriteLine($"{c.Key} --> {c.Value}");
            }


        }
    }
}
