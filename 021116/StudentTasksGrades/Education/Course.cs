﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentTasksGrades.Education
{
    class Course
    {
        private int _capacity;
        private readonly List<Student> _students;
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
            _name = "NoName";
            _capacity = 0;
            _durationInHours = 0;
        }

        public Course(string name, int capacity): this()
        {
            _name = name;
            _capacity = capacity;
        }

        public Course(string name, int durationInHours, int capacity) : this(name, capacity)
        {
            _durationInHours = durationInHours;
        }

        public void AddStudent(Student student)
        {
            if(_students.Count() < _capacity )
            {
                if(!CheckStudentExists(student.Id))
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
                throw new CourseFullException($"{this.ToString()} is already full!");
            }
        }

        public void RemoveStudent(int studentId)
        {
            var student = _students.Find(s => s.Id == studentId);
            _students.Remove(student);
        }

        public bool CheckStudentExists(int studentId)
        {
            return _students.Exists(s => s.Id == studentId);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
