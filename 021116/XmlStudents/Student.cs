namespace XmlStudents
{
    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Id { get; private set; }
        private static int nextId = 0;

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            Id = nextId++;
        }
    }
}