using PhoneDirectory.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PhoneDirectory.Command;
using PhoneDirectory.Readers;

namespace PhoneDirectory
{
    public class PhonebookCommandFileReader : FileReader, ICommandReader
    {
        public PhonebookCommandFileReader(string filePath) : base(filePath)
        {
        }

        public List<PhonebookCommand> GetCommands()
        {
            List<PhonebookCommand> commands = new List<PhonebookCommand>();

            using (this.reader)
            {
                string text = this.reader.ReadToEnd();
                string[] lines = text.Split(new char[] { '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    var command = ReadCommand(line);
                    commands.Add(command);
                }

                this.reader.Close();
                return commands;
            }
        }

        public PhonebookCommand ReadCommand(string line)
        {
            string commandType = line.Substring(0, line.IndexOf('(')).Trim();

            string commandArgs = line.Split('(', ')')[1].Trim();
            string[] args = commandArgs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].Trim();
            }

            Commands type;

            PhonebookCommand command = null;

            switch (commandType)
            {
                case "find": type = Commands.Find; command = new FindCommand(args); break;
                case "serialize": type = Commands.Serialize; command = new SerializeCommand(args); break;
                case "add": type = Commands.add; command = new AddCommand(args); break;
                default: type = Commands.Find; command = new FindCommand(args); break;
            }

            return command;

        }
    }
}
