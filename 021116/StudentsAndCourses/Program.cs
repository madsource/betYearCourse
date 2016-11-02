using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of courses: ");
            int numberOfCourse;
            int.TryParse(Console.ReadLine(), out numberOfCourse);

            List<Course> courses = new List<Course>();

            for (int i = 0; i < numberOfCourse; i++)
            {
                Console.Write("\nCourse " + (i + 1) +"\n");
                string[] courseInfos = Console.ReadLine().Split(new string[] { "//"}, StringSplitOptions.None);
                string cName = courseInfos[0];
                int cDuration = int.Parse(courseInfos[1]);
                int cCapacity = int.Parse(courseInfos[2]);

                Course course = new Course(cName, cDuration, cCapacity);
                courses.Add(course);
            }
        }
    }
}
