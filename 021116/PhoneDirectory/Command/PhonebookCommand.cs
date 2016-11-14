using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    public abstract class PhonebookCommand
    {
        public string[] Arguments { get; set; }

        public PhonebookCommand(string[] arguments)
        {
            this.Arguments = arguments;
        }
    }
}
