using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StudentsAndCourses.Education;
using StudentsAndCourses.Education.ExceptionTypes;
using StudentTasksGrades.Education;
using StudentTasksGrades.Education;

namespace StudentTasksGrades
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

            Console.WriteLine(
                "\nPlease, add tasks to students. Format: <studentId> <courseId> <taskName>//<score> \nTo finish write \"quit\"");

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower().Equals("quit")) break;
                
                string pattern = @"(\s)|(\//)";
                string[] line = Regex.Split(input, pattern);

                int studentId = int.TryParse(line[0], out studentId) ? studentId : -1;
                int courseId = int.TryParse(line[2], out courseId) ? courseId : -1;

                string taskName = line[4];
                float taskGrade = float.Parse(line[6]);
                
                try
                {
                    Academy.AddTaskToStudent(courseId, studentId, new AcademyTask(taskName, taskGrade));
                }
                catch (StudentNotFoundException se)
                {
                    Console.WriteLine("Student not found: " + se.Message);
                }
                catch (CourseNotFoundException ce)
                {
                    Console.WriteLine("Course not found: " + ce.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintAcademyInfo();

        }

        public static void PrintAcademyInfo()
        {
            List<Student> studentsGradesList = new List<Student>();
            Dictionary<Student, float> scoreDictionary = Academy.Students.ToDictionary(s => s, s => s.GetTotalScore());
   
            Console.WriteLine($"TOP STUDENTS: -------------\n ");

            //foreach (var stud in scoreDictionary.OrderByDescending(s => s.Value)
            //    .Where(s => s.Value >= 95).OrderBy(s => s.Key.Name).ThenBy(s => s.Value))
            //{
            //    Console.WriteLine($"{stud.Key.Name} - {stud.Value}");
            //}

            foreach (var stud in scoreDictionary.OrderByDescending(s => s.Value))
            {
                Console.WriteLine($"{stud.Key.Name} - {stud.Value}%");
            }

        }

        public static void CreateCoursesList(int count)
        {
            Console.WriteLine($"\nPlease, add {count} courses. Format: <name>//<capacity>");
            for (int i = 0; i < count; i++)
            {
                Console.Write("\nCourse " + (i + 1) + "\n");
                string[] courseInfos = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                string cName = courseInfos[0];
                int cCapacity = int.TryParse(courseInfos[1], out cCapacity) ? cCapacity : 0;

                Academy.AddCourse(cName, cCapacity);
            }
        }

        public static void CreateStudentsList(int count)
        {
            Console.WriteLine($"\nPlease, subscribe {count} students to courses. Format: <student name>//<course id>");

            for (int i = 0; i < count; i++)
            {
                Console.Write("\nStudent " + (i + 1) + "\n");
                string[] studentsInfo = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                string sName = studentsInfo[0];
                int courseId = int.TryParse(studentsInfo[1], out courseId) ? courseId : 0;

                try
                {
                    var studentId = Academy.AddStudent(sName);
                    Academy.SignupStudentToCourse(studentId, courseId);
                }
                catch (PersonAgeException pe)
                {
                    Console.WriteLine(pe.Message);
                    i--;
                }
            }
        }
    }
}
