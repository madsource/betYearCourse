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

            VisualizeList(madList);

            madList.Sort();

            VisualizeList(madList);

            // Start reading size of array
            Console.Write("Give me size: ");
            int size;
            while(!int.TryParse(Console.ReadLine(), out size));
            var ar = CreateTwoDimArray(size);
            Console.Write("Give me coords to increment: ");
            string[] coords = Console.ReadLine().Trim().Split(' ');
            int coord0 = int.Parse(coords[0]);
            int coord1 = int.Parse(coords[1]);
            ar[coord0][coord1]++;
            PrintTwoDimArray(ar);
        }
        
        static void VisualizeList(List<string> list)
        {
            Console.WriteLine("Start =========\n");

            foreach (var l in list)
            {
                System.Console.WriteLine(l);
            }

            Console.WriteLine("\nEnd   =========\n");
        }

        static int[][] CreateTwoDimArray(int size)
        {
            int[][] theArray = new int[size][];
            int counter = 1;

            for (int i = 0; i < size; i++)
            {
                theArray[i] = new int[size];
                Console.WriteLine();

                for (int j = 0; j < size; j++)
                {
                    theArray[i][j] = counter++;
                    Console.Write(theArray[i][j] + " ");
                }
            }

            return theArray;          
        }

        static void PrintTwoDimArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine();

                for (int j = 0; j < array.Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
            }
        }
    }
}
