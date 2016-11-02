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

        public int Id
        {
            get { return _id; }
        }

        public Course()
        {
            _id++;
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
            _students.Add(student);
        }

        public void removeStudent(Student student)
        {
            _students.Remove(student);
        }

        public bool checkStudentExists(Student student)
        {
            return _students.Exists(s => s.Name == student.Name);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
