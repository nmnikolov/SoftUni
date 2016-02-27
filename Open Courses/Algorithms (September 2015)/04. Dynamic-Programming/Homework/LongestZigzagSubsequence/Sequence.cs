namespace LongestZigzagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sequence
    {
        public static void Main()
        {
            var sequence =
                Console.ReadLine().Split(new[] { ", ", " ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var longestSeq = FindLongestIncreasingSubsequence(sequence);
            Console.WriteLine(string.Join(" ", longestSeq));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] sequence)
        {
            var len = new int[2, sequence.Length];
            var prev = new int[2, sequence.Length];
            var maxLen = 1;
            var lastIndex = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                len[0, i] = 1;
                len[1, i] = 1;
                prev[0, i] = -1;
                prev[1, i] = -1;

                for (int j = 0; j < i ; j++)
                {
                    if (sequence[i] - sequence[j] > 0)
                    {
                        if (len[1, j] + 1 > len[0, i])
                        {
                            len[0, i] = len[1, j] + 1;
                            prev[0, i] = j;
                        }
                    } 
                    else if (sequence[i] - sequence[j] < 0)
                    {
                        if (len[0, j] + 1 > len[1, i])
                        {
                            len[1, i] = len[0, j] + 1;
                            prev[1, i] = j;
                        }
                    }
                }

                if (len[0, i] > maxLen || len[1, i] > maxLen)
                {
                    maxLen = Math.Max(len[0, i], len[1, i]);
                    lastIndex = i;
                }
            }

            return RecoverLis(sequence, len, maxLen, lastIndex, prev);
        }

        private static int[] RecoverLis(int[] sequence, int[,] len, int max, int lastIndex, int[,] prev)
        {
            var row = len[0, lastIndex] == max ? 0 : 1;
            var longestSeq = new List<int>();

            while (lastIndex != -1)
            {
                longestSeq.Add(sequence[lastIndex]);
                lastIndex = prev[row, lastIndex];
                row = row == 0 ? 1 : 0;
            }

            longestSeq.Reverse();

            return longestSeq.ToArray();
        }
    }
}
