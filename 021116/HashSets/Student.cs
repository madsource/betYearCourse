using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSets
{
    public class Student: Human

    {
        public int Number { get; set; }
        public Teacher Teacher { get; set; }

        public Student(int number, string name) : base(name)
        {
            Number = number;
        }

        //public override bool Equals(object obj)
        //{
        //    Student otherStudent = obj as Student;

        //    if (otherStudent == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        if (otherStudent.Number == this.Number)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
    }
}
