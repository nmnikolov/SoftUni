namespace NestedLoops
{
    using System;

    public class NestedLoops
    {
        private static int loops = 0;
        private const int StartNumber = 1;

        public static void Main()
        {
            var nestedLoops = ParseUserInput();
            int endNum = nestedLoops;

            int[] arr = new int[nestedLoops];
            GenCombs(arr, 0, StartNumber, endNum);

            Console.WriteLine("Loops combinations: {0}", loops);
        }

        static void GenCombs(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                loops++;
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    arr[index] = i;
                    GenCombs(arr, index + 1, startNum, endNum);
                }
            }
        }

        private static int ParseUserInput()
        {
            Console.Write("Enter number of nested loops: ");
            int n;
            bool boolParse = int.TryParse(Console.ReadLine(), out n);

            while (!boolParse)
            {
                Console.Write("Invalid number. Try again: ");
                boolParse = int.TryParse(Console.ReadLine(), out n);
            }

            return n;
        }
    }
}