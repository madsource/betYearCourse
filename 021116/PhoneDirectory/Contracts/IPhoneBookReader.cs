using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Contracts
{
    public interface IPhoneBookReader
    {
        List<PhoneDirectory.IEntity> ReadRecords();
        PhoneDirectory.IEntity CreatePerson(string personLine);
    }
}
