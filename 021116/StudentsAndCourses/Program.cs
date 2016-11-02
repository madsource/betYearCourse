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
            int coursesCount;
            int.TryParse(Console.ReadLine(), out coursesCount);
            List<Course> coursesList = CreateCoursesList(coursesCount);

            Console.Write("Enter number of students: ");
            int studentsCount;
            int.TryParse(Console.ReadLine(), out studentsCount);
            List<Student> studentsList = CreateStudentsList(studentsCount);
        }

        public static List<Course> CreateCoursesList(int count)
        {
            List<Course> courses = new List<Course>();

            for (int i = 0; i < count; i++)
            {
                Console.Write("\nCourse " + (i + 1) + "\n");
                string[] courseInfos = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                string cName = courseInfos[0];
                int cDuration = int.Parse(courseInfos[1]);
                int cCapacity = int.Parse(courseInfos[2]);

                Course course = new Course(cName, cDuration, cCapacity);
                courses.Add(course);
            }

            return courses;
        }

        public static List<Student> CreateStudentsList(int count)
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                Console.Write("\nStudent " + (i + 1) + "\n");
                string[] studentsInfo = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                string cName = studentsInfo[0];
                int cAge = int.Parse(studentsInfo[1]);

                Student student = new Student(cName, cAge);
                students.Add(student);
            }

            return students;
        }
    }
}
