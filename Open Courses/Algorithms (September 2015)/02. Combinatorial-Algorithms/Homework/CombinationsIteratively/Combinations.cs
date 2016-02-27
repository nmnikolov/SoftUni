namespace CombinationsIteratively
{
    using System;
    using System.Collections.Generic;

    public class Combinations
    {
        private static int countOfCombinations = 0;

        public static void Main()
        {
            Console.Write("Enter N: ");
            var n = int.Parse(Console.ReadLine());

            Console.Write("Enter K: ");
            var k = int.Parse(Console.ReadLine());

            foreach (int[] c in GetCombinations(k, n))
            {
                Console.WriteLine(string.Join(", ", c));
                countOfCombinations++;
            }

            Console.WriteLine("Total combinations: {0}", countOfCombinations);
        }

        public static IEnumerable<int[]> GetCombinations(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == m)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}