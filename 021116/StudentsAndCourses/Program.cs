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
            CreateCoursesList(coursesCount);

            Console.Write("\nEnter number of students: ");
            int studentsCount;
            int.TryParse(Console.ReadLine(), out studentsCount);
            CreateStudentsList(studentsCount);

            Console.WriteLine("\nPlease, assign students to courses. Format: <studentID courseId> \nTo finish write \"quit\"");

            while(Console.ReadLine() != "quit")
            {
                string[] line = Console.ReadLine().Split(' ');
                int studentId = int.Parse(line[0]);
                int courseId = int.Parse(line[1]);
                try
                {
                    Academy.signupStudentToCourse(studentId, courseId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }

            printAcademyInfo();

        }

        public static void printAcademyInfo()
        {
            List < Course > orderedCourses = Academy.Courses.OrderBy(p => p.Name).ToList();

            foreach (var c in orderedCourses)
            {
                Console.WriteLine($"{c.Name} - {c.DurationInHours} hours");
                List < Student > orderedStudents = c.Students.OrderBy(s => s.Age).ToList();

                foreach (var s in orderedStudents)
                {
                    Console.WriteLine($"##{s.Name} - {s.Age} years old");
                }

            }
        }

        public static void CreateCoursesList(int count)
        {            
            for (int i = 0; i < count; i++)
            {
                Console.Write("\nCourse " + (i + 1) + "\n");
                string[] courseInfos = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                string cName = courseInfos[0];
                int cDuration = int.Parse(courseInfos[1]);
                int cCapacity = int.Parse(courseInfos[2]);
                
                Academy.AddCourse(cName, cDuration, cCapacity);
            }
        }

        public static void CreateStudentsList(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write("\nStudent " + (i + 1) + "\n");
                string[] studentsInfo = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                string cName = studentsInfo[0];
                int cAge = int.Parse(studentsInfo[1]);

                Academy.AddStudent(cName, cAge);
            }
        }
    }
}
