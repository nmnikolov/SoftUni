using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Manipulator
{
    public class ArrayManipulator
    {
        private static int[] array;

        public static void Main()
        {
            ReadInput();
        }

        private static void ReadInput()
        {
            array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                ProcessCommand(command);

                command = Console.ReadLine();
            }

            PrintArray(array);
        }

        private static void ProcessCommand(string commandLine)
        {
            string[] commandParams = commandLine.Split(' ');
            string command = commandParams[0];

            switch (command)
            {
                case "exchange":
                    ProcessExchangeCommand(commandParams);
                    break;
                case "max":
                    ProcessMaxCommand(commandParams);
                    break;
                case "min":
                    ProcessMinCommand(commandParams);
                    break;
                case "first":
                    ProcessFirstCommand(commandParams);
                    break;
                case "last":
                    ProcessLastCommand(commandParams);
                    break;
            }
        }

        private static void ProcessLastCommand(string[] commandParams)
        {
            int count = int.Parse(commandParams[1]);
            int mod = commandParams[2] == "even" ? 0 : 1;

            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            IEnumerable<int> result = array.Reverse().Where(n => n % 2 == mod).Take(count).Reverse();

            PrintArray(result);
        }

        private static void ProcessFirstCommand(string[] commandParams)
        {
            int count = int.Parse(commandParams[1]);
            int mod = commandParams[2] == "even" ? 0 : 1;

            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            IEnumerable<int> result = array.Where(n => n % 2 == mod).Take(count);

            PrintArray(result);
        }

        private static void ProcessMinCommand(string[] commandParams)
        {
            int mod = commandParams[1] == "even" ? 0 : 1;

            int index = array.MinIndex(mod);
            PrintIndex(index);
        }

        private static void ProcessMaxCommand(string[] commandParams)
        {
            int mod = commandParams[1] == "even" ? 0 : 1;

            int index = array.MaxIndex(mod);

            PrintIndex(index);
        }

        private static void ProcessExchangeCommand(string[] commandParams)
        {
            int index = int.Parse(commandParams[1]);

            if (index < 0 || index >= array.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            int[] leftArr = array.Take(index + 1).ToArray();
            int[] rightArr = array.Skip(index + 1).Take(array.Length - index - 1).ToArray();

            array = rightArr.Concat(leftArr).ToArray();
        }

        private static void PrintArray(IEnumerable<int> result)
        {
            Console.WriteLine("[{0}]", string.Join(", ", result));
        }

        private static void PrintIndex(int index)
        {
            if (index == -1)
            {
                Console.WriteLine("No matches");
                return;
            }

            Console.WriteLine(index);
        }
    }

    public static class Extensions
    {
        public static int MaxIndex<T>(this IEnumerable<T> sequence, int mod)
            where T : IComparable<T>
        {
            int maxIndex = -1;
            T maxValue = default(T); // Immediately overwritten anyway

            int index = 0;
            foreach (T value in sequence)
            {
                if ((value.CompareTo(maxValue) >= 0 || maxIndex == -1) && int.Parse(value.ToString()) % 2 == mod)
                {
                    maxIndex = index;
                    maxValue = value;
                }
                index++;
            }
            return maxIndex;
        }

        public static int MinIndex<T>(this IEnumerable<T> sequence, int mod)
            where T : IComparable<T>
        {
            int minIndex = -1;
            T minValue = default(T); // Immediately overwritten anyway

            int index = 0;
            foreach (T value in sequence)
            {
                if ((value.CompareTo(minValue) <= 0 || minIndex == -1) && int.Parse(value.ToString()) % 2 == mod)
                {
                    minIndex = index;
                    minValue = value;
                }
                index++;
            }
            return minIndex;
        }
    }
}