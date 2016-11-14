using PhoneDirectory.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    public interface ICommandReader
    {
        List<PhonebookCommand> GetCommands();
        PhonebookCommand ReadCommand(string line);
    }
}
