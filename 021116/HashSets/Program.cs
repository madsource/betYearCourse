using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HashSets
{
    class Program
    {
        static void Main(string[] args)
        {
            // HashSet has Unique item values
            // HashSet has no sorting
            // Does not add the same element twice is given

            HashSet<int> studentNumbers = new HashSet<int>();
            Teacher teacher = new Teacher("Stamat");

            IEqualityComparer<Student> comparer = new StudentsComparer();
            HashSet<Student> students = new HashSet<Student>(comparer);

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "-1")
                {
                    break;
                }
                string[] splitted = line.Split();

                Student student = new Student(int.Parse(splitted[1]), splitted[0]);

                if (students.Contains(student))
                {
                    Console.WriteLine("Try again! This student's number is already added!");
                }
                else
                {
                    students.Add(student);
                    teacher.Students.Add(student);
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{ student.Name} - {student.Number}");
            }
            
        }
    }
}
