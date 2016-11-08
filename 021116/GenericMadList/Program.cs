using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMadList
{
    class Program
    {
        static void Main(string[] args)
        {
           
            MadList<int> list = new MadList<int>();

            list.Add(666);
            list.Add(999);
            //list.Add("Qga");
            //list.Add("Dqdo");
            //list.Add("Qg");

            list.Remove(999);

            Console.WriteLine(list.Contains(7));
            Console.WriteLine(list.Contains(666));

        }
    }
}
