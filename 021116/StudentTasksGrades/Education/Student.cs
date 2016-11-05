using System;
using System.Collections.Generic;
using StudentsAndCourses.Education;
using StudentsAndCourses.Education.ExceptionTypes;

namespace StudentTasksGrades.Education
{
    class Student : Person
    {
        private int _courseId;
        private static int _id = 0;
        public List<AcademyTask> Tasks { get; set; }
        
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

        public Student()
        {
            _courseId = -1;
            Id = _id++;
            Console.WriteLine($"StudentID: {Id}\n");
            Tasks = new List<AcademyTask>();
        }

        public Student(string name, int age) : base(name, age)
        {
            _courseId = -1;
            Id = _id++;
            Console.WriteLine($"StudentID: {Id}\n");
            Tasks = new List<AcademyTask>();
        }

        public Student(string name) : base(name)
        {
            _courseId = -1;
            Id = _id++;
            Console.WriteLine($"StudentID: {Id}\n");
            Tasks = new List<AcademyTask>();
        }

        public override string ToString()
        {
            return base.Name;
        }

        internal float GetTotalScore()
        {
            float sumOfGrades = 0;
            Tasks.ForEach(delegate(AcademyTask task)
            {
                sumOfGrades += task.Score;
            });

            return sumOfGrades / Tasks.Count;
        }
    }
}
