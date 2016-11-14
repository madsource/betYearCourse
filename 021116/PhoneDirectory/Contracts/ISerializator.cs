using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Contracts
{
    public interface ISerializator<T>
    {
        void Serialize(IDisposable writer, T obj);
        T Deserialize(IDisposable reader);
    }
}
