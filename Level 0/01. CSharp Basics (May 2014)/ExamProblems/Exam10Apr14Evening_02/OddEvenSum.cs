using System;

class OddEvenSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sumOdd = 0;
        int sumEven = 0;

        for (int i = 1; i <= 2 * n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (i % 2 == 0)
            {
                sumEven += number;
            }
            else
            {
                sumOdd += number;
            }
        }

        if (sumOdd == sumEven)
        {
            Console.WriteLine("Yes, sum={0}", sumEven);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sumEven - sumOdd));
        }
    }
}