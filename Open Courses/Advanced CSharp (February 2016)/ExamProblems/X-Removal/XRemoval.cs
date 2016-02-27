using System;
using System.Collections.Generic;
using System.Linq;

namespace XRemoval
{
    public class XRemoval
    {
        private static List<string> arr = new List<string>();
        private static List<string[]> output = new List<string[]>();

        public static void Main()
        {
            ReadInput();
            Parse();
            Print();
        }

        private static void Print()
        {
            foreach (var line in output)
            {
                Console.WriteLine(string.Join("", line));
            }
        }

        private static void Parse()
        {
            for (var row = 0; row < arr.Count - 2; row++)
            {
                for (var col = 0; col < arr[row].Length - 2; col++)
                {
                    var character = arr[row][col].ToString().ToLower();
                    if (col + 1 < arr[row + 1].Length &&
                        col  + 2< arr[row + 2].Length &&
                        arr[row][col + 2].ToString().ToLower() == character &&
                        arr[row + 1][col + 1].ToString().ToLower() == character &&
                        arr[row + 2][col].ToString().ToLower() == character &&
                        arr[row + 2][col + 2].ToString().ToLower() == character)
                    {
                        output[row][col] = "";
                        output[row][col + 2] = "";
                        output[row + 1][col + 1] = "";
                        output[row + 2][col] = "";
                        output[row + 2][col + 2] = "";
                    }
                }
            }
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                arr.Add(line);

                output.Add(line.ToCharArray().Select(c => c.ToString()).ToArray());
                line = Console.ReadLine();
            }
        }
    }
}