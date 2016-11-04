using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentTasksGrades.Education.ExceptionTypes;

namespace StudentTasksGrades.Education
{
    internal class AcademyTask
    {
        private static readonly List<string> TakenNames = new List<string>();

        public float Grade { get; set; }
        public string Name { get; set; }
        public DateTime AddedOn { get; set; }

        public AcademyTask()
        {
            Name = "Noname";
            AddedOn = DateTime.Now;
        }

        public AcademyTask(string name, float grade) : this()
        {
            if (!TakenNames.Contains(name))
            {
                Name = name;
                TakenNames.Add(name);
            }
            else
            {
                throw new TaskTakenNameException($"\"{name}\" is taken name!");
            }

            Grade = grade;
        }
    }

    
}
