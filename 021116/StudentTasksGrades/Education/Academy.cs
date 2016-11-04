using StudentsAndCourses.Education.ExceptionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentTasksGrades.Education;

namespace StudentTasksGrades.Education
{
    class Academy
    {
        public static List<Course> Courses { get; private set; } = new List<Course>();
        public static List<Student> Students { get; private set; } = new List<Student>();

        public static void SignupStudentToCourse(int studentId, int courseId)
        {
            foreach (var c in Courses)
            {
                if(courseId == c.Id)
                {
                    // Assign course to the given Student's instance
                    foreach (var s in Students)
                    {
                        if (studentId == s.Id)
                        {
                            try
                            {
                                c.AddStudent(s);
                            }
                            catch (StudentIsBusyException e)
                            {
                                Console.WriteLine("Student is busy: " + e.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            break;

                        } else if (Students.FindIndex(ls => ls.Id == s.Id) == Students.Count - 1)
                        {
                            // last entry reached and id not found
                            throw new StudentNotFoundException("Wrong student id!");
                        }
                    }
                    break;

                } else if( Courses.FindIndex(lc => lc.Id == c.Id) == Courses.Count - 1 )
                {
                    // last entry reached and id not found
                    throw new CourseNotFoundException("Wrong course id!");
                }
            }
        }

        public static void AddCourse(string name, int duration, int capacity)
        {
            var course = new Course(name, duration, capacity);
            Courses.Add(course);
        }

        public static void AddStudent(string name, int age)
        {          
            var student = new Student(name, age);
            Students.Add(student);                 
        }

        internal static void AddCourse(string name, int capacity)
        {
            var course = new Course(name, capacity);
            Courses.Add(course);
        }

        internal static int AddStudent(string name)
        {
            var student = new Student(name);
            Students.Add(student);
            return student.Id;
        }

        internal static void AddTaskToStudent(int courseId, int studentId, AcademyTask task)
        {
            var student = Students.Find(s => s.Id == studentId);
            var course = Courses.Find(c => c.Id == courseId);

            if (student.CourseId == courseId)
            {
                student.Tasks.Add(task);
            }
            else
            {
                throw  new StudentIsBusyException($"{student} is not assigned to the {course}");
            }
        }
    }
}
