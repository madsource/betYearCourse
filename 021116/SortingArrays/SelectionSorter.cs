using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArrays
{
    public class SelectionSorter : Sorter
    {

        public SelectionSorter(int[] array) : base(array)
        {

        }

        internal override int[] SortArray()
        {
            int[] unsortedArray = this.UnsortedArray;

            //Array.Copy(array, unsortedArray, array.Length);

            for (int i = 0; i < unsortedArray.Length; i++)
            {
                var min = unsortedArray[i];
                int minIndex = i;
                for (int j = i; j < unsortedArray.Length; j++)
                {
                    if (min <= unsortedArray[j])
                    {
                        min = unsortedArray[j];
                        minIndex = j;
                    }
                }

                int temp = unsortedArray[i];
                unsortedArray[i] = min;
                unsortedArray[minIndex] = temp;
            }

            return unsortedArray;
        }
    }
}
