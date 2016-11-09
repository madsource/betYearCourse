using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesAndStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            
            Console.WriteLine("Dequeued element: "+ queue.Dequeue()); // removes first in e.g. 5
            Console.WriteLine("peek element: "+queue.Peek() + "\n"); //tells which one is to be removed e.g. 5 without removing

            // removing all
            while (queue.Count > 0)
            {
                int element = queue.Dequeue();
                Console.WriteLine(element);
            }

            // Stacks
            Console.WriteLine("--STACK -------");

            Stack<int> stack = new Stack<int>();

            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);

            Console.WriteLine(stack.Pop());

            while (stack.Count > 0)
            {
                var element = stack.Pop();
                Console.WriteLine(element);
            }

            // Linked list - dvoino svurzan spisak

            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.AddFirst(5);
            LinkedListNode<int> el = linkedList.First;
            //el.Next; 
            //el.Previous;

        }

        // Dept-first searching with stack example / uses the call stack in c#/
        //private static void Dfs(Node node)
        //{
        //    foreach (var item in node.Children)
        //    {
        //        Dfc(item);
        //    }
        //}
    }
}
