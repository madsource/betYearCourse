using PersonTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    class Student : Person
    {
        private Course _course;
        private static int _uniqueId = 0;

        public Course Course
        {
            get {  return _course; }
            set {
                if (_course.Equals(null))
                {
                    _course = value;
                } else
                {
                    throw new Exception("Student is already signed up!");
                }
            }
        }

        public int Id { get; private set; }

        public Student(string name, int age):base(name, age)
        {
            Id = _uniqueId++;
            Console.WriteLine($"StudentID: {Id}");
        }

        public override string ToString()
        {
            return base.Name;
        }


    }
}
