using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMadList
{
    class GenericClass<T> where T : struct // only value types
    {
        public T GenProp { get; set; }

        public GenericClass(T genProp)
        {
            GenProp = genProp;
        }

        public override string ToString()
        {
            return GenProp.ToString();
        }
    }
}
