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
            list.Add(888);
            list.Add(777);
            //list.Add("Qga");
            //list.Add("Dqdo");
            //list.Add("Qg");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Remove2(999);

            Console.WriteLine(list.Contains(7));
            Console.WriteLine(list.Contains(666));

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
