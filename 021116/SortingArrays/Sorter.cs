using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingArrays.Contracts;

namespace SortingArrays
{
    public abstract class Sorter
    {
        protected int[] UnsortedArray { get; set; }
        public int[] SortedArray { get; set; }
        public ILogger Logger { get; set; }

        public Sorter(int[] array, ILogger logger)
        {
            this.UnsortedArray = array;
            this.Logger = logger;
        }

        internal abstract int[] SortArray();
    }
}
