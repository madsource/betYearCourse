using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingArrays.Contracts;

namespace SortingArrays
{
    class BubleSorter : Sorter
    {
        public BubleSorter(int[] array, ILogger logger):base(array, logger)
        {
            SortType = SortType.Buble;
        }
        internal override int[] SortArray()
        {
            Logger.WriteLine($"\ninfo :: Sorted by {SortType} sorter.\n");
            return null;
        }
    }
}
