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
           
            MadList list = new MadList();

            list.Add("Baba");
            list.Add("Qga");
            list.Add("Dqdo");
            list.Add("Qg");

            list.Remove("Qg");

            Console.WriteLine(list.Contains("Dqdo"));
            Console.WriteLine(list.Contains("Dqdkaaa"));

            list.OnRemove += DoStuff;

            PrintName("Stamat");

            var genClass = new GenericClass<char>('O');

            PrintName(genClass);

        }

        public static void DoStuff(object sender, ChangeDelegateArgs args)
        {
            Console.WriteLine("\n And finally doing some stuff :)))");
        }

        private static T PrintName<T>(T name)
        {
            Console.WriteLine($"Your object's name is: {name}");
            return name;
        }
    }
}
