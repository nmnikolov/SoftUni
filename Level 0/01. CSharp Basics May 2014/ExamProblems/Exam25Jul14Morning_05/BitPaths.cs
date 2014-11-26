using System;
using System.Linq;

class BitPaths
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[8];

        for (int i = 0; i < n; i++)
        {
            int[] bits = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int currentBit = 3 - bits[0];
            for (int j = 0; j < 8; j++)
            {
                numbers[j] ^= 1 << currentBit;
                if (j < 7)
                {
                    currentBit -= bits[j + 1];
                }
            }
        }

        int sum = numbers.Sum();
        Console.WriteLine(Convert.ToString(sum, 2));
        Console.WriteLine(sum.ToString("X"));
    }
}