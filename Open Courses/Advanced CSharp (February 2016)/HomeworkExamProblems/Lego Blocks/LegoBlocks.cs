using System;
using System.Collections.Generic;
using System.Linq;

namespace LegoBlocks
{
    public class LegoBlocks
    {
        private static int length = 0;
        private static bool found = true;
        private static int total = 0;

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            List<List<int>> firstArray = new List<List<int>>();
            List<List<int>> secondArray = new List<List<int>>();

            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                List<int> arr = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                firstArray.Add(arr);
                total += arr.Count;
            }

            for (int i = 0; i < rows; i++)
            {
                List<int> arr = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Reverse().Select(int.Parse).ToList();
                secondArray.Add(arr);
                total += arr.Count;
            }

            for (int i = 0; i < rows; i++)
            {
                List<int> concat = firstArray[i].Concat(secondArray[i]).ToList();

                if (length == 0)
                {
                    length = concat.Count();
                    result.Add(concat);
                    continue;
                }

                if (length != concat.Count)
                {
                    found = false;
                    break;
                }

                result.Add(concat);
            }

            if (found)
            {
                foreach (var item in result)
                {
                    Console.WriteLine("[{0}]", string.Join(", ", item));
                }
            }
            else
            {
                Console.WriteLine("The total number of cells is: {0}", total);
            }
        }
    }
}
