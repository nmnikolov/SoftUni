namespace LimitedCoinsSum
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
            var numbers = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] dp = new int[targetSum + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[targetSum + 1];
            }

            var result = Count(numbers, dp, targetSum, numbers.Length - 1);
            Console.WriteLine(result);
        }

        public static int Count(int[] numbers, int[][] dp, int sum, int k)
        {
            int j;

            if (sum <= 0 || k < 0)
            {
                return 0;
            }

            if (dp[sum][k] > 0)
            {
                return dp[sum][k];
            }
            else
            {
                if (numbers[k] == sum)
                {
                    dp[sum][k] = 1;
                }

                dp[sum][k] += Count(numbers, dp, sum - numbers[k], k - 1);
                j = k;
                while (j >= 0 && numbers[j] == numbers[k])
                {
                    j--;
                }

                dp[sum][k] += Count(numbers, dp, sum, j);

            }

            return dp[sum][k];
        }
    }
}