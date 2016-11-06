using System;
using System.Collections.Generic;
using StudentTasksGrades.Education.ExceptionTypes;

namespace StudentTasksGrades.Education
{
    internal class AcademyTask
    {
        private static readonly List<string> TakenNames = new List<string>();

        public float Score { get; private set; }
        public string Name { get; set; }
        public DateTime AddedOn { get; private set; }

        public AcademyTask()
        {
            Name = "Noname";
            AddedOn = DateTime.Now;
        }

        public AcademyTask(string name, float score) : this()
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

            Score = score;
        }
    }

    
}
