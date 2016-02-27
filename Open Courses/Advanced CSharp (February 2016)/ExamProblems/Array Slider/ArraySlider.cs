using System;
using System.Linq;
using System.Numerics;

namespace ArraySlider
{
    public class ArraySlider
    {
        private static BigInteger[] array;
        private static long index = 0;

        public static void Main()
        {
            //string line = Regex.Replace(Console.ReadLine(), "[\\s]+", " ");

            //array = Regex.Split(line, "[\\s]+").Select(long.Parse).ToArray();

            array = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
            ReadCommands();
            PrintArray();
        }

        private static void PrintArray()
        {
            Console.WriteLine("[{0}]", string.Join(", ", array));
        }

        private static void ReadCommands()
        {
            string line = Console.ReadLine();

            while (line != "stop")
            {
                string[] commandParams = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int offset = int.Parse(commandParams[0]);
                string operation = commandParams[1];
                long operand = long.Parse(commandParams[2]);

                ProcessCommand(offset, operation, operand);
                line = Console.ReadLine();
            }            
        }

        private static void ProcessCommand(int offset, string operation, long operand)
        {
            FindNextIndex(offset);
            switch (operation)
            {
                case "&":
                    array[index] &= operand;
                    break;
                case "|":
                    array[index] |= operand;
                    break;
                case "^":
                    array[index] ^= operand;
                    break;
                case "+":
                    array[index] += operand;
                    break;
                case "-":
                    array[index] -= operand;
                    array[index] = array[index] < 0 ? 0 : array[index];
                    break;
                case "*":
                    array[index] *= operand;
                    break;
                case "/":
                    array[index] /= operand;
                    break;
            }
        }

        private static void FindNextIndex(int offset)
        {
            offset = offset % array.Length;

            index = (index + offset) % array.Length;

            if (index < 0)
            {
                index += array.Length;
            }
        }
    }
}