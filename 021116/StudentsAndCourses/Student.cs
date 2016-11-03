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
        private static int _id = 0;

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

        public int Id
        {
            get { return _id; }
            private set
            {
                _id = value;
            }
        }

        public Student(string name, int age):base(name, age)
        {
            Id = _id;
            _id++;
        }

        public override string ToString()
        {
            return base.Name;
        }


    }
}
