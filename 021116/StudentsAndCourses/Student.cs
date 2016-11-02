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
        private int _id;
        private Course _course;

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

        public Student()
        {
            _id++;
        }

        public Student(string name, int age):base(name, age)
        {
            _id++;
        }

        public override string ToString()
        {
            return base.Name;
        }


    }
}
