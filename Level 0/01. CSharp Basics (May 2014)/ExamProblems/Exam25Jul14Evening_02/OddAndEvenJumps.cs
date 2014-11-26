using System;

class OddAndEvenJumps
{
    static void Main()
    {
        string input = string.Join("", Console.ReadLine().ToLower().Split(' '));
        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());
        long oddSum = 0;
        long evenSum = 0;
        int countOdd = 1;
        int countEven = 1;

        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                if (countOdd % oddJump == 0)
                {
                    oddSum *= (int)input[i];
                }
                else
                {
                    oddSum += (int)input[i];
                }
                countOdd++;
            }
            else
            {
                if (countEven % evenJump == 0)
                {
                    evenSum *= (int)input[i];
                }
                else
                {
                    evenSum += (int)input[i];
                }
                countEven++;
            }
        }
        Console.WriteLine("Odd: {0}", oddSum.ToString("X"));
        Console.WriteLine("Even: {0}", evenSum.ToString("X"));
    }
}