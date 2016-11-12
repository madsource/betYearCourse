using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class PhonebookCommandReader : ICommandReader
    {
        public string FilePath { get; set; }

        public PhonebookCommandReader(string filePath)
        {
            this.FilePath = filePath;
        }
        public List<PhonebookCommand> GetCommands()
        {
            List<PhonebookCommand> commands = new List<PhonebookCommand>();
            StreamReader reader = new StreamReader(this.FilePath);

            string text;
            using (reader)
            {
                text = reader.ReadToEnd();
                string[] lines = text.Split(new char[] { '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    PhonebookCommand command = ReadCommand(line);
                    commands.Add(command);
                }
            }

            return commands;
        }

        public PhonebookCommand ReadCommand(string line)
        {

            string commandType = line.Substring(0, line.IndexOf('(')).Trim();

            string commandArgs = line.Split('(', ')')[1];
            string[] args = commandArgs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            Commands type;

            switch (commandType)
            {
                case "find": type = Commands.Find; break;
                case "serialize": type = Commands.Serialize; break;
                case "add": type = Commands.add; break;
                default: type = Commands.Find; break;
            }

            return new PhonebookCommand(type, args);

        }
    }
}
