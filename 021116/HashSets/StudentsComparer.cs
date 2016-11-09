using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSets
{
    class StudentsComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            Student otherStudent = x as Student;

            if (otherStudent == null)
            {
                return false;
            }
            else
            {
                if (otherStudent.Number == y.Number)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int GetHashCode(Student obj)
        {
            return obj.Number.GetHashCode();
        }
    }
}
