using System;

class HalfSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long sum1 = 0;
        long sum2 = 0;

        for (int i = 0; i < n * 2; i++)
        {
            if (i < n)
            {
                sum1 += long.Parse(Console.ReadLine());
            }
            else
            {
                sum2 += long.Parse(Console.ReadLine());
            }
        }

        if (sum1 == sum2)
        {
            Console.WriteLine("Yes, sum={0}", sum1);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sum1 - sum2));
        }
    }
}