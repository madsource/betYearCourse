using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses.Education.ExceptionTypes
{
    internal class CourseNotFoundException : Exception
    {
        public CourseNotFoundException(string message) : base(message)
        {
        }
    }
}
