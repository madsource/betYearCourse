using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingArrays.Contracts;

namespace SortingArrays
{
    public class SelectionSorter : Sorter
    {

        public SelectionSorter(int[] array, ILogger logger) : base(array, logger)
        {
            SortType = SortType.Selection;
        }

        internal override int[] SortArray()
        { 
            var sortedArray = this.UnsortedArray.Select(x => x).ToArray();

            for (int i = 0; i < sortedArray.Length; i++)
            {
                var min = sortedArray[i];
                int minIndex = i;
                for (int j = i; j < sortedArray.Length; j++)
                {
                    if (min <= sortedArray[j])
                    {
                        min = sortedArray[j];
                        minIndex = j;
                    }
                }

                int temp = sortedArray[i];
                sortedArray[i] = min;
                sortedArray[minIndex] = temp;
            }

            Logger.WriteLine($"Sorted at: {DateTime.Now}" );
            Logger.WriteLine($"\ninfo :: Sorted by {SortType} sorter.\n");

            return sortedArray;
        }
    }
}
