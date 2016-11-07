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
        }

        internal override int[] SortArray()
        {
            return this.UnsortedArray.OrderBy(x => x).ToArray();
        }
    }
}
