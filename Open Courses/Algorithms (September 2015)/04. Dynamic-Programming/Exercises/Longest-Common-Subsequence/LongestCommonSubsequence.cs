namespace Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestCommonSubsequence
    {
        public static void Main()
        {
            Console.Write("firstStr = ");
            var firstStr = Console.ReadLine();
            Console.Write("secondStr = ");
            var secondStr = Console.ReadLine();

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);
        }

        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            int firstLen = firstStr.Length + 1;
            int secondLen = secondStr.Length + 1;

            var lcs = new int[firstLen, secondLen];

            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (firstStr[row - 1] == secondStr[col - 1])
                    {
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        lcs[row, col] = Math.Max(lcs[row - 1, col], lcs[row, col - 1]);
                    }
                }
            }
            
            var sequence = RetrieveLCS(firstStr, secondStr, lcs);

            return sequence;
        }

        private static string RetrieveLCS(string firstStr, string secondStr, int[,] lcs)
        {
            var sequence = new List<char>();
            int i = firstStr.Length;
            int j = secondStr.Length;
            
            while (i > 0 && j > 0)
            {
                if (firstStr[i - 1] == secondStr[j - 1])
                {
                    sequence.Add(firstStr[i - 1]);
                    i--;
                    j--;
                }
                else if (lcs[i, j] == lcs[i - 1, j])
                {
                    i--;
                }
                else
                {
                    j--;
                }
            }

            sequence.Reverse();

            return new string(sequence.ToArray());
        }
    }
}
