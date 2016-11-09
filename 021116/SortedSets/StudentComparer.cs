using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashSets;

namespace SortedSets
{
    public class StudentComparer : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            if (x < y)
            {
                return 1;
            } else if (x == y)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
