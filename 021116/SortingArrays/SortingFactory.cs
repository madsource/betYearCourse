using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingArrays.Contracts;
using SortingArrays;

namespace SortingArrays
{
    public static class SortingFactory
    {
        public static Sorter Create(SortType sortType, int[] array, ILogger logger)
        {
            switch (sortType)
            {
                case SortType.Selection:
                    return new SelectionSorter(array, logger);
                case SortType.Buble:
                    return new BubleSorter(array, logger);
                case SortType.Linq:
                    return new LinqSort(array, logger);
                default: return null;
            }
        }
    }
}
