using System;
using System.Runtime.Serialization;

namespace StudentTasksGrades.Education
{
    [Serializable]
    internal class CourseFullException : Exception
    {
        public CourseFullException()
        {
        }

        public CourseFullException(string message) : base(message)
        {
        }

        public CourseFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CourseFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}