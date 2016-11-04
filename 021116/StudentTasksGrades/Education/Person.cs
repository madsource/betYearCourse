using StudentsAndCourses.Education.ExceptionTypes;

namespace StudentTasksGrades.Education
{
    class Person
    {
        private string _name;
        private int _age;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        public int Age {
            get { return _age; }
            set { _age = value; }
        }

        public Person()
        {
            _name = "No name";
            _age = 0;
        }

        public Person(string name):this()
        {
            _name = name;
        }

        public Person(string name, int age):this(name)
        {
            if(age >= 0)
            {
                _age = age;

            } else
            {
                throw new PersonAgeException("Age of person can not be negative!");
            }
        }
    }
}
