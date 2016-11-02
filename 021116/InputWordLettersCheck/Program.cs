using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputWordLettersCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word <only letters> : ");
            string word = Console.ReadLine();

            if (!word.Trim().All(c => Char.IsLetter(c) || c == '_'))
            {
                Console.WriteLine("This word CONTAINS not allowed symbols!\nPlease enter only letters.");
            }
            else
            {
                Console.WriteLine("Yeah, good word!");
            }            
        }
    }
}
