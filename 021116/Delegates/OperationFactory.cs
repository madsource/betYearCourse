using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public static class OperationFactory
    {
        public delegate float ExecuteOperation(int x, int y);

        public static ExecuteOperation CreateOperations(OperationTypes operation)
        {
            ExecuteOperation execOperations;

            switch (operation)
            {
                case OperationTypes.add:
                    execOperations = Add;
                    break;
                case OperationTypes.substract:
                    execOperations = Substract;
                    break;
                case OperationTypes.multiply:
                    execOperations = Multiply;
                    break;
                case OperationTypes.devide:
                    execOperations = Divide;
                    break;
                default:
                    execOperations = Add;
                    break;
            }

            return execOperations;
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

        public static float Divide(int x, int y)
        {
            return (float)x / y;
        }
    }
}
