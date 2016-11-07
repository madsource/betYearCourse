using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArrays
{
    public abstract class Sorter
    {
        protected int[] UnsortedArray { get; set; }
        public int[] SortedArray { get; set; }

        public Sorter(int[] array)
        {
            this.UnsortedArray = array;
        }

        internal abstract int[] SortArray();
    }
}
