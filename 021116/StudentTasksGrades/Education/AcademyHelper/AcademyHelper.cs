using StudentTasksGrades.Education;
using System.Collections.Generic;
using System.Linq;

namespace StudentsAndCourses.Education.AcademyHelper
{
    internal static class AcademyHelper
    {
        public static float GetCourseScore(Course course)
        {
            float courseScore = 0;

            course.Students.ForEach(delegate (Student s) {

                courseScore += s.GetTotalScore();

            });

            return courseScore;
        }

        public static List<Course> GetTopCourses(int limit)
        {
            Dictionary<Course, float> topCourses = new Dictionary<Course, float>();

            Academy.Courses.ForEach( delegate(Course course) {

                var courseScore = GetCourseScore(course);

                if(courseScore >= 95)
                {
                    topCourses.Add(course, courseScore);
                }

            });

            return topCourses.OrderByDescending(c => c.Value).Take(limit).Select(c => c.Key).ToList();
        }

        public static Dictionary<Student, float> GetTopStudents()
        {
            Dictionary<Student, float> scoreDictionary = Academy.Students.ToDictionary(s => s, s => s.GetTotalScore());

            return scoreDictionary.OrderByDescending(r => r.Value)
                    .Where(s => s.Value >= 95)
                    .OrderBy(s => s.Key.Name)
                    .ThenBy(s => s.Value)
                    .ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
