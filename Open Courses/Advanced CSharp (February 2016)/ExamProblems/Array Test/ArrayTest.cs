using System;
using System.Linq;
using System.Numerics;

namespace ArrayTest
{
    public class ArrayTest
    {
        private const char ArgumentsDelimiter = ' ';

        private static BigInteger[] array;

        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            array = Console.ReadLine()
                .Split(new char[] { ArgumentsDelimiter }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

            string commandLine = Console.ReadLine();

            while (!commandLine.Equals("stop"))
            {
                string[] stringParams = commandLine.Split(ArgumentsDelimiter);
                string command = stringParams[0];
                long[] args = new long[2];

                if (command.Equals("add") ||
                    command.Equals("subtract") ||
                    command.Equals("multiply"))
                {

                    args[0] = long.Parse(stringParams[1]);
                    args[1] = long.Parse(stringParams[2]);
                }

                PerformAction(command, args);

                PrintArray();
                commandLine = Console.ReadLine();
            }
        }

        private static void PerformAction(string action, long[] args)
        {
            long pos = args[0] - 1;
            long value = args[1];

            switch (action)
            {
                case "multiply":
                    array[pos] *= value;
                    break;
                case "add":
                    array[pos] += value;
                    break;
                case "subtract":
                    array[pos] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft();
                    break;
                case "rshift":
                    ArrayShiftRight();
                    break;
            }
        }

        private static void ArrayShiftRight()
        {
            var arr1 = array.Take(array.Length - 1);
            var arr2 = array.Skip(array.Length - 1).Take(1);

            array = arr2.Concat(arr1).ToArray();
        }

        private static void ArrayShiftLeft()
        {
            var arr1 = array.Take(1);
            var arr2 = array.Skip(1).Take(array.Length - 1);

            array = arr2.Concat(arr1).ToArray();
        }

        private static void PrintArray()
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}