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
            int coursesCount = int.TryParse(Console.ReadLine(), out coursesCount) ? coursesCount : 0;
            CreateCoursesList(coursesCount);

            Console.Write("\nEnter number of students: ");
            int studentsCount = int.TryParse(Console.ReadLine(), out studentsCount) ? studentsCount : 0;
            CreateStudentsList(studentsCount);

            Console.WriteLine("\nPlease, assign students to courses. Format: <studentID courseId> \nTo finish write \"quit\"");
            
            while(true)
            {
                string input = Console.ReadLine();
                if (input.Equals("quit")) break;

                string[] line = input.Split(new char[0]);
                int studentId = int.TryParse(line[0], out studentId) ? studentId : -1;
                int courseId = int.TryParse(line[1], out courseId) ? courseId : -1;
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
            List < Course > orderedCourses = Academy.Courses.OrderBy(c => c.Name).ToList();

            foreach (var c in orderedCourses)
            {
                Console.WriteLine($"\n---{c.Name} - {c.DurationInHours} hours");
                List < Student > orderedStudents = c.Students.OrderBy(s => s.Age).ToList();

                foreach (var s in orderedStudents)
                {
                    Console.WriteLine($"## {s.Name} - {s.Age} years old");
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
                int cDuration = int.TryParse(courseInfos[1], out cDuration) ? cDuration : 0;
                int cCapacity = int.TryParse(courseInfos[2], out cCapacity) ? cCapacity : 0;
                
                Academy.AddCourse(cName, cDuration, cCapacity);
            }
        }

        public static void CreateStudentsList(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write("\nStudent " + (i + 1) + "\n");
                string[] studentsInfo = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                string sName = studentsInfo[0];
                int sAge = int.TryParse(studentsInfo[1], out sAge) ? sAge: 0;

                Academy.AddStudent(sName, sAge);
            }
        }
    }
}
