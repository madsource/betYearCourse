using StudentsAndCourses.Education.ExceptionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses.Education
{
    class Student : Person
    {
        private int _courseId;
        private static int _id = 0;
        
        public int CourseId
        {
            get {  return _courseId; }
            set {
                if (_courseId < 0)
                {
                    _courseId = value;
                } else
                {
                    throw new StudentIsBusyException($"{this.ToString()} is already signed for a course with id {_courseId}!");
                }
            }
        }

        public int Id { get; private set; }

        public Student(string name, int age):base(name, age)
        {
            _courseId = -1;
            Id = _id++;
            Console.WriteLine($"StudentID: {Id}\n");
        }

        public override string ToString()
        {
            return base.Name;
        }


    }
}
