using System;
using System.Collections.Generic;
using System.Linq;

class OddEvenElements
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        List<decimal> odd = new List<decimal>();
        List<decimal> even = new List<decimal>();

        if (input[0] != "")
        {
            for (int i = 1; i <= input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even.Add(decimal.Parse(input[i - 1]));
                }
                else
                {
                    odd.Add(decimal.Parse(input[i - 1]));
                }
            }
        }

        if (odd.Count == 0)
        {
            Console.Write("OddSum=No, OddMin=No, OddMax=No, ");
        }
        else
        {
            Console.Write("OddSum={0:0.##}, OddMin={1:0.##}, OddMax={2:0.##}, ", odd.Sum(), odd.Min(), odd.Max());
        }

        if (even.Count == 0)
        {
            Console.Write("EvenSum=No, EvenMin=No, EvenMax=No");
        }
        else
        {
            Console.Write("EvenSum={0:0.##}, EvenMin={1:0.##}, EvenMax={2:0.##}", even.Sum(), even.Min(), even.Max());
        }
    }
}