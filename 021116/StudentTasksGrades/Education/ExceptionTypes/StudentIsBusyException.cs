using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses.Education.ExceptionTypes
{
    internal class StudentIsBusyException : Exception
    {
        public StudentIsBusyException(string message): base(message)
        {
            
        }
    }
}
