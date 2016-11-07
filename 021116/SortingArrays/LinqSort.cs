using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingArrays.Contracts;

namespace SortingArrays
{
    class LinqSort : Sorter
    {
        public LinqSort(int[] array, ILogger logger) : base(array, logger)
        {
            SortType = SortType.Linq;
        }

        internal override int[] SortArray()
        {
            Logger.WriteLine($"\ninfo :: Sorted by {SortType} sorter.\n");
            return this.UnsortedArray.OrderBy(x => x).ToArray();
        }
    }
}
