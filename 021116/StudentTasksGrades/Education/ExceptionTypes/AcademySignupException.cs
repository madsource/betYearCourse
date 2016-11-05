using System;
using System.Runtime.Serialization;

namespace StudentTasksGrades.Education
{
    [Serializable]
    internal class AcademySignupException : Exception
    {
        public AcademySignupException()
        {
        }

        public AcademySignupException(string message) : base(message)
        {
        }

        public AcademySignupException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AcademySignupException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}