using System;
using System.Linq;

namespace Command_Interpreter
{   
    public class CommandInterpreter
    {
        public static bool error = false;
        private static string[] numbers;

        public static void Main()
        {
            numbers = Console.ReadLine().Trim().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            ReadInput();
        }

        private static void ReadInput()
        {
            string commandLine = Console.ReadLine();

            while (commandLine != "end")
            {
                ParseCommand(commandLine);

                commandLine = Console.ReadLine();
            }
            
            PrintArray();
        }

        private static void ParseCommand(string commandLine)
        {
            string[] commandParameters = commandLine.Split(' ');

            switch (commandParameters[0])
            {
                case "reverse":
                    ProcessReverseCommand(commandParameters);
                    break;
                case "sort":
                    ProcessSortCommand(commandParameters);
                    break;
                case "rollLeft":
                    ProcessRollLeft(commandParameters);
                    break;
                case "rollRight":
                    ProcessRollRight(commandParameters);
                    break;
            }       
        }

        private static void ProcessReverseCommand(string[] commandParameters)
        {
            int start = int.Parse(commandParameters[2]);
            int count = int.Parse(commandParameters[4]);

            if (!IsValidStart(start) || !IsValidCount(count) || (start + count) > numbers.Length)
            {
                PrintError();
                return;
            }

            string[] reversed = numbers.Skip(start).Take(count).Reverse().ToArray();

            for (int i = 0; i < count; i++)
            {
                numbers[start + i] = reversed[i];
            }            
        }

        private static void ProcessSortCommand(string[] commandParameters)
        {
            int start = int.Parse(commandParameters[2]);
            int count = int.Parse(commandParameters[4]);

            if (!IsValidStart(start) || !IsValidCount(count) || (start + count) > numbers.Length)
            {
                PrintError();
                return;
            }

            string[] sorted = numbers.Skip(start).Take(count).OrderBy(e => e).ToArray();

            for (int i = 0; i < count; i++)
            {
                numbers[start + i] = sorted[i];
            }            
        }

        private static void ProcessRollLeft(string[] commandParameters)
        {
            int count = int.Parse(commandParameters[1]);

            if (count < 0)
            {
                PrintError();
                return;
            }     

            int times = count % numbers.Length;

            string[] left = numbers.Take(times).ToArray();
            string[] right = numbers.Skip(times).Take(numbers.Length - times).ToArray();

            numbers = right.Concat(left).ToArray();
        }

        private static void ProcessRollRight(string[] commandParameters)
        {
            int count = int.Parse(commandParameters[1]);

            if (count < 0)
            {
                PrintError();
                return;
            }

            int times = count % numbers.Length;

            string[] left = numbers.Take(numbers.Length - times).ToArray();
            string[] right = numbers.Skip(numbers.Length - times).Take(times).ToArray();

            numbers = right.Concat(left).ToArray();
        }

        private static void PrintArray()
        {
            Console.WriteLine("[{0}]", string.Join(", ", numbers));
        }

        private static void PrintError()
        {
            Console.WriteLine("Invalid input parameters.");
        }

        private static bool IsValidStart(int number)
        {
            return number >= 0 && number < numbers.Length;
        }

        private static bool IsValidCount(int number)
        {
            return number >= 0 && number <= numbers.Length;
        }
    }
}