using System;
using System.Text.RegularExpressions;
using StudentsAndCourses.Education.ExceptionTypes;
using StudentTasksGrades.Education;
using StudentsAndCourses.Education.AcademyHelper;

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

            Regex pattern = new Regex(@"^\d+\s\d+\s(\w|\-)+\/\/(\d{1,2}|\d{1,2}[.,]\d{1,2}|100)$");

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower().Equals("quit")) break;
                
                if (pattern.IsMatch(input))
                {
                    string splitPattern = @"(\s)|(\//)";
                    string[] line = Regex.Split(input, splitPattern);

                    int studentId = int.TryParse(line[0], out studentId) ? studentId : -1;
                    int courseId = int.TryParse(line[2], out courseId) ? courseId : -1;

                    string taskName = line[4];

                    double taskGrade;
                    if (Double.TryParse(line[6], out taskGrade))
                    {
                        try
                        {
                            Academy.AddTaskToStudent(courseId, studentId, taskName, (float)taskGrade);
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
                    } else
                    {
                        Console.WriteLine("Wrong score input! Try again.");
                    }                
                    
                } else
                {
                    Console.WriteLine("Invalid format! Please, try again.");
                }
                
            }

            PrintAcademyInfo();

        }

        public static void PrintAcademyInfo()
        {
         
            Console.WriteLine($"\nTOP STUDENTS (score >= 95%) : -------------\n ");

            foreach (var rec in AcademyHelper.GetTopStudents())
            {
                Console.WriteLine($"{rec.Key.Name} - {rec.Value}");
            }

            Console.WriteLine($"\nTOP COURSES (score >= 95%) : -------------\n ");

            foreach (var course in AcademyHelper.GetTopCourses(3))
            {
                Console.WriteLine($"{course.Name}");
            }

        }

        public static void CreateCoursesList(int count)
        {
            Console.WriteLine($"\nPlease, add {count} courses. Format: <name>//<capacity>");
            Regex pattern = new Regex(@"^[\w\-\#]+\/\/\d{1,5}$");

            for (int i = 0; i < count; i++)
            {                                                
                Console.Write("\nCourse " + (i + 1) + "\n");
                var input = Console.ReadLine();

                if (pattern.IsMatch(input))
                {
                    string[] courseInfos = input.Split(new string[] { "//" }, StringSplitOptions.None);
                    string cName = courseInfos[0];
                    int cCapacity = int.TryParse(courseInfos[1], out cCapacity) ? cCapacity : 0;

                    Academy.AddCourse(cName, cCapacity);
                } else
                {
                    Console.WriteLine("Wrong format! Please, try again.");
                    i--;
                }                
                
            }
        }

        public static void CreateStudentsList(int count)
        {
            Console.WriteLine($"\nPlease, subscribe {count} students to courses. Format: <student name>//<course id>");
            Regex pattern = new Regex(@"^[A-Za-z\-\s]+\/\/\d+$");

            for (int i = 0; i < count; i++)
            {
                Console.Write("\nStudent " + (i + 1) + "\n");
                var input = Console.ReadLine();

                if(pattern.IsMatch(input))
                {
                    string[] studentsInfo = input.Split(new string[] { "//" }, StringSplitOptions.None);
                    string sName = studentsInfo[0];
                    int courseId = int.TryParse(studentsInfo[1], out courseId) ? courseId : 0;

                    try
                    {
                        if(Academy.Courses.Exists(c => c.Id == courseId))
                        {
                            var studentId = Academy.AddStudent(sName);
                            try
                            {
                                Academy.SignupStudentToCourse(studentId, courseId);
                            }
                            catch (AcademySignupException ae)
                            {

                                Console.WriteLine(ae.Message);
                                if(ae.InnerException is CourseFullException || ae.InnerException is StudentIsBusyException)
                                {
                                    i--;
                                }
                            }
                            
                        } else
                        {
                            Console.WriteLine("Enter a valid course id!");
                            i--;
                        }                       
                        
                    }
                    catch (PersonAgeException pe)
                    {
                        Console.WriteLine(pe.Message);
                        i--;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        i--;
                    }
                } else
                {
                    Console.WriteLine("Wrong format! Please, try again.");
                    i--;
                }                
            }
        }
    }
}
