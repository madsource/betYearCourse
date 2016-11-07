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

            Sorter sorter = null;
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

            switch (sortType)
            {
                case SortType.Selection:
                    sorter = new SelectionSorter(array, logger);
                    break;
                case SortType.Buble:
                    sorter = new BubleSorter(array, logger);
                    break;
                case SortType.Linq:
                    sorter = new LinqSort(array, logger);
                    break;
                default: break;
            }

            var sortedArray = sorter.SortArray();

            logger.WriteLine("\nUnsorted:");
            logger.WriteLine(String.Join(",", array));

            logger.WriteLine("\nSorted:");
            logger.WriteLine(String.Join(",", sortedArray));
        }
    }
}
