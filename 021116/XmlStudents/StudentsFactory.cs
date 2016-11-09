using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XmlStudents
{
    class StudentsFactory
    {
        private static string[] names = {"Pesho", "Gosho", "Ivan", "Eli", "Kiko", "Petq", "Hristo", "Dragan", "Petkan", "Svetla"};

        public static List<Student> CreateStudentsList(int count)
        {
            List<Student> studentsList = new List<Student>();
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                int randAge = rand.Next(18, 60);
                int nameIndex = rand.Next(0, 9);
                string name = names[nameIndex];

                Student student = new Student(name, randAge);
                studentsList.Add(student);
            }

            return studentsList;
        }
    }
}
