using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            ListTracker tracker = new ListTracker();

            tracker.OnChange += () => Console.WriteLine("Changed!");

            Func<string, int> test = (string gosho) =>
            {
                Console.WriteLine(gosho);
                return 5;
            };

            tracker.Add(test("Peshoo"));
            Console.WriteLine(tracker.List[0]);
        }
    }
}
