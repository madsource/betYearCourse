using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class PhonebookCommand
    {
        public Commands CommandType { get; set; }
        public string[] Arguments { get; set; }

        public PhonebookCommand(Commands commandType, string[] arguments)
        {
            this.CommandType = commandType;
            this.Arguments = arguments;
        }
    }
}
