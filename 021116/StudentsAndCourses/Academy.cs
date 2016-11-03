using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    class Academy
    {
        private static List<Course> _courses = new List<Course>();
        private static List<Student> _students = new List<Student>();

        public static List<Course> Courses
        {
            get
            {
                return _courses;
            }
            private set
            {
                _courses = value;
            }
        }

        public static List<Student> Students
        {
            get
            {
                return _students;
            }
            private set
            {
                _students = value;  
            }
        }

        public static void signupStudentToCourse(int studentId, int courseId)
        {
            foreach (var c in _courses)
            {
                if(courseId == c.Id)
                {                    
                    c.Students.Add(_students.Find( s => s.Id == studentId));
                    foreach (var s in _students)
                    {
                        if (studentId == s.Id)
                        {
                            try
                            {                                
                                s.Course = _courses.Find( co => co.Id == courseId);
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
            _courses.Add(course);
            //course.Id = Courses.IndexOf(course);
        }

        public static void AddStudent(string name, int age)
        {
            Student student = new Student(name, age);
            _students.Add(student);
            //student.Id = Students.IndexOf(student);
        }
    }
}
