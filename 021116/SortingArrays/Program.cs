using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of elements: ");
            int count = int.Parse(Console.ReadLine());

            
            int[] array = new int[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter element {i}: ");
                array[i] = int.Parse(Console.ReadLine().Trim());
            }

            Sorter sorter = new SelectionSorter(array);

            int[] sortedArray = sorter.SortArray();

            Console.WriteLine("Sorted:");

            Console.WriteLine(String.Join(",", sortedArray));

            //foreach (var i in sortedArray)
            //{
            //    Console.Write($"{i} ");
            //}
        }
    }
}
