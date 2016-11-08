using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void ChangeDelegate();
    class ListTracker
    {
        public List<int> List { get; set; }
        public event ChangeDelegate OnChange;

        public ListTracker()
        {
            this.List = new List<int>();
        }

        public void Add(int element)
        {
            this.List.Add(element);
            this.OnChange();
        }
    }
}
