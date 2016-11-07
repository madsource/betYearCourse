using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Number X: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Number Y: ");
            int y = int.Parse(Console.ReadLine());

            Console.Write("\nEnter operation type: ");
            string operationTypeInput = Console.ReadLine().ToLower();

            OperationTypes operation;

            switch (operationTypeInput)
            {
                case "+":
                    operation = OperationTypes.add;
                    break;
                case "-":
                    operation = OperationTypes.substract;
                    break;
                case "*":
                    operation = OperationTypes.multiply;
                    break;
                case "/":
                    operation = OperationTypes.devide;
                    break;
                default:
                    operation = OperationTypes.add;
                    break;
            }

            var del = OperationFactory.CreateOperations(operation);

            Console.WriteLine($"Result from {x} {operation} {y} = {del(x,y)}");
        }
    }
}
