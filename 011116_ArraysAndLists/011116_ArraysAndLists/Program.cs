using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011116_ArraysAndLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var madList = new List<String>();

            madList.Add("1Baba");
            madList.Add("xBaba2");
            madList.Add("Baba3");

            Visualize(madList);

            madList.Sort();

            Visualize(madList);
        }

        static void Visualize(List<string> list)
        {
            System.Console.WriteLine("Start =========\n");

            foreach (var l in list)
            {
                System.Console.WriteLine(l);
            }

            System.Console.WriteLine("\nEnd   =========\n");
        }
    }
}
