using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadListTask
{
    class Program
    {
        static void Main(string[] args)
        {
           
            MadList list = new MadList();

            list.Add("Baba");
            list.Add("Qga");
            list.Add("Dqdo");
            list.Add("Qg");

            list.Remove("Qg");

            Console.WriteLine(list.Contains("Dqdo"));
            Console.WriteLine(list.Contains("Dqdkaaa"));
        }
    }
}
