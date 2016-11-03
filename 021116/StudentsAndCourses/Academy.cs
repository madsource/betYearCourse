﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    class Academy
    {
        public static List<Course> Courses { get; private set; } = new List<Course>();
        public static List<Student> Students { get; private set; } = new List<Student>();

        public static void signupStudentToCourse(int studentId, int courseId)
        {
            foreach (var c in Courses)
            {
                if(courseId == c.Id)
                {
                    // Assign course to the given Student's instance
                    foreach (var s in Students)
                    {
                        if (studentId == s.Id)
                        {
                            try
                            {                                
                                s.CourseId = courseId;
                                if (!c.checkStudentExists(studentId))
                                {
                                    c.addStudent(s);
                                }
                                else
                                {
                                    Console.WriteLine("This student is already in that course!");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            break;

                        } else if (Students.FindIndex(ls => ls.Id == s.Id) == Students.Count - 1)
                        {
                            // last entry reached and id not found
                            throw new Exception("Student with that id is NOT FOUND!");
                        }
                    }
                    break;

                } else if( Courses.FindIndex(lc => lc.Id == c.Id) == Courses.Count - 1 )
                {
                    // last entry reached and id not found
                    throw new Exception("Course with that id is NOT FOUND!");
                }
            }
        }

        public static void AddCourse(string name, int duration, int capacity)
        {
            Course course = new Course(name, duration, capacity);
            Courses.Add(course);
        }

        public static void AddStudent(string name, int age)
        {
            Student student = new Student(name, age);
            Students.Add(student);
        }
    }
}
