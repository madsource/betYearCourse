using PhoneBookApp.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public interface ICommandReader
    {
        List<PhonebookCommand> GetCommands();
        PhonebookCommand ReadCommand(string line);
    }
}
