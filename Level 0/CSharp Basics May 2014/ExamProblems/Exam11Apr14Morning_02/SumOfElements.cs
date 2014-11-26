using System;
using System.Collections.Generic;
using System.Linq;

class SumOfElements
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        List<long> list = new List<long>();

        for (int i = 0; i < input.Length; i++)
        {
            list.Add(int.Parse(input[i]));
        }

        long max = list.Max();
        long sum = list.Sum() - max;

        if (sum == max)
        {
            Console.WriteLine("Yes, sum={0}", sum);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sum - max));
        }
    }
}