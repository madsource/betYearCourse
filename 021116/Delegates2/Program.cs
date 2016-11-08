using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Returns void, all is params
            Action<string, int> helloDelegate = Hello;

            helloDelegate("Gosho", 2);
            // Returns int, last is return type
            Func<string, int> helloDel = Hello2;
        }

        private static int Hello2(string arg)
        {
            return 3;
        }

        private static void Hello(string name, int age)
        {
            Console.WriteLine($"Name: {name} - age: {age}");
        }

        public static void MethodExecutor(Action<string, int> action )
        {
            action("Gosho", 5);
        }
    }
}
