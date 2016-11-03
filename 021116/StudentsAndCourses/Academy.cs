using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    class Academy
    {
        public static List<Course> Courses { get; private set; } = new List<Course>();
        public static List<Student> Students { get; private set; } = new List<Student>();

        public static void signupStudentToCourse(int studentId, int courseId)
        {
            foreach (var c in Courses)
            {
                if(courseId == c.Id)
                {
                    Student student = Students.Find(s => s.Id == studentId);

                    if (!c.checkStudentExists(student))
                    {
                        c.addStudent(student);
                    }else
                    {
                        Console.WriteLine("This student is already in that course!");
                    }

                    // Assign course to the given student's instance
                    foreach (var s in Students)
                    {
                        if (studentId == s.Id)
                        {
                            try
                            {                                
                                s.Course = Courses.Find( co => co.Id == courseId);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    }
                    break;

                } else
                {
                    throw new Exception("Not existing course!");
                }
            }
        }

        public static void AddCourse(string name, int duration, int capacity)
        {
            Course course = new Course(name, duration, capacity);
            Courses.Add(course);
            //course.Id = Courses.IndexOf(course);
        }

        public static void AddStudent(string name, int age)
        {
            Student student = new Student(name, age);
            Students.Add(student);
            //student.Id = Students.IndexOf(student);
        }
    }
}
