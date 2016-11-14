using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    public class PhonebookEntityComparer : IEqualityComparer<IEntity>
    {
        public bool Equals(IEntity x, IEntity y)
        {
            return (x.PhoneNumber == y.PhoneNumber && x.Name == y.Name);
        }

        public int GetHashCode(IEntity obj)
        {
            return obj.PhoneNumber.GetHashCode();
        }
    }
}
