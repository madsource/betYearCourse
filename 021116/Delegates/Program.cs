using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate float ExecuteOperation(int x, int y);

        static void Main(string[] args)
        {
            Console.Write("Number X: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Number Y: ");
            int y = int.Parse(Console.ReadLine());

            Console.Write("\nEnter operation type: ");
            string operationTypeInput = Console.ReadLine().ToLower();

            OperationTypes operation;
            ExecuteOperation execOperations;

            switch (operationTypeInput)
            {
                case "+":
                    operation = OperationTypes.add;
                    execOperations = Add;
                    break;
                case "-":
                    operation = OperationTypes.substract;
                    execOperations = Substract;
                    break;
                case "*":
                    operation = OperationTypes.multiply;
                    execOperations = Multiply;
                    break;
                case "/":
                    operation = OperationTypes.devide;
                    execOperations = Devide;
                    break;
                default:
                    operation = OperationTypes.add;
                    execOperations = Add;
                    break;
            }

            Console.WriteLine($"Result from {x} {operation} {y} = {execOperations(x,y)}");
        }
        
        public static float Add(int x, int y)
        {
            return x + y;
        }

        public static float Substract(int x, int y)
        {
            return x - y;
        }

        public static float Multiply(int x, int y)
        {
            return x * y;
        }

        public static float Devide(int x, int y)
        {
            return (float) x / y;
        }
    }
}
