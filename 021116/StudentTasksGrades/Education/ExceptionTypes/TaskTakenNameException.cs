using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTasksGrades.Education.ExceptionTypes
{
    internal class TaskTakenNameException : Exception
    {
        public TaskTakenNameException(string message) : base(message)
        {
        }
    }
}
