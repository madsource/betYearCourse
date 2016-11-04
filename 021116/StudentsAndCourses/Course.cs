using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    class Course
    {
        private int _capacity;
        private List<Student> _students;
        private string _name;
        private int _durationInHours;
        private static int _id = 0;

        public int Capacity {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public List<Student> Students
        {
            get { return _students; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int DurationInHours
        {
            get { return _durationInHours; }
            set { _durationInHours = value; }
        }

        public int Id { get; private set; }

        public Course()
        {
            Id = _id++;
            Console.WriteLine($"CourseID: {Id}\n");

            _students = new List<Student>();
        }

        public Course(string name, int durationInHours, int capacity):this()
        {
            _name = name;
            _durationInHours = durationInHours;
            _capacity = capacity;            
        }

        public void addStudent(Student student)
        {
            if(_students.Count() < _capacity )
            {
                if(!checkStudentExists(student.Id))
                {                                        
                     student.CourseId = this.Id;
                     _students.Add(student);                                         
                }
                else
                {
                    throw new ArgumentException($"{student} is already in that course!");
                }
            }
            else
            {
                throw new Exception($"{this.ToString()} is already full!");
            }
        }

        public void removeStudent(int studentId)
        {

            var student = _students.Find(s => s.Id == studentId);
            _students.Remove(student);
        }

        public bool checkStudentExists(int studentId)
        {
            return _students.Exists(s => s.Id == studentId);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
