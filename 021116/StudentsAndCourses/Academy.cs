using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    class Academy
    {
        public List<Course> Courses { get; set; }
        public List<Student> Student { get; set; }

        public void signupStudentToCourse(Student student, Course course)
        {
            course.Students.Add(student);
        }
    }
}
