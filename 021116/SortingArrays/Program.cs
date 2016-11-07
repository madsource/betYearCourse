using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingArrays.Contracts;

namespace SortingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of elements: ");
            int count = int.Parse(Console.ReadLine());

            
            var array = new int[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter element {i}: ");
                array[i] = int.Parse(Console.ReadLine().Trim());
            }

            ILogger logger = new ConsoleLogger();
            Sorter sorter = new LinqSort(array, logger);

            var sortedArray = sorter.SortArray();

            logger.WriteLine("\nUnsorted:");
            logger.WriteLine(String.Join(",", array));

            logger.WriteLine("\nSorted:");
            logger.WriteLine(String.Join(",", sortedArray));
        }
    }
}
