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
            ILogger logger = new ConsoleLogger();

            logger.Write("Enter number of elements: ");
            int count = int.Parse(Console.ReadLine());

            
            var array = new int[count];

            for (int i = 0; i < count; i++)
            {
                logger.Write($"Enter element {i}: ");
                array[i] = int.Parse(Console.ReadLine().Trim());
            }

            Console.Write("\nEnter sort type: ");
            string sortTypeInput = Console.ReadLine().ToLower();
            
            var sortType = SortType.Selection;

            switch (sortTypeInput)
            {
                case "selection":
                    sortType = SortType.Selection;
                    break;
                case "buble":
                    sortType = SortType.Buble;
                    break;
                case "linq":
                    sortType = SortType.Linq;
                    break;
                default: break;
            }

            Sorter sorter = SortingFactory.Create(sortType, array, logger);

            var sortedArray = sorter.SortArray();

            logger.WriteLine("\nUnsorted:");
            logger.WriteLine(String.Join(",", array));

            logger.WriteLine("\nSorted:");
            logger.WriteLine(String.Join(",", sortedArray));
        }
    }
}
