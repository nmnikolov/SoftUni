namespace CoinsSum
{
    using System;
    using System.Linq;

    public class CoinsSum
    {
        public static void Main()
        {
            Console.WriteLine("Enter target sum:");
            var targetSum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter numbers separated with \",\"");
            var nums = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var ways = GetSumWays(nums, targetSum);

            Console.WriteLine("Total combinations: " + ways.Length);

            // Uncomment to print possible combinations
            //foreach (var way in ways)
            //{
            //    Console.WriteLine(string.Join(" ", way));
            //}
        }

        public static int[][] GetSumWays(int[] array, int k)
        {
            int[][][] ways = new int[k + 1][][];
            ways[0] = new[] { new int[0] };

            for (int i = 1; i <= k; i++)
            {
                ways[i] = (
                    from val in array
                    where i - val >= 0
                    from subway in ways[i - val]
                    where subway.Length == 0 || subway[0] >= val
                    select Enumerable.Repeat(val, 1)
                        .Concat(subway)
                        .ToArray()
                ).ToArray();
            }

            return ways[k];
        }
    }
}
