using System;
using System.Collections.Generic;
using System.Linq;

class Pairs
{
    static void Main()
    {
        string[] elements = Console.ReadLine().Split(' ');  
        int value = int.Parse(elements[0]) + int.Parse(elements[1]);
        bool equal = true;
        int maxDiff = 0;

        for (int i = 2; i < elements.Length; i+= 2)
        {
            int tempValue = int.Parse(elements[i]) + int.Parse(elements[i + 1]);

            if (tempValue != value)
            {
                equal = false;

                if (Math.Abs(tempValue - value) > maxDiff)
                {
                   maxDiff = Math.Abs(tempValue - value); 
                }

                value = tempValue;
            }                 
        }

        if (equal)
        {
            Console.WriteLine("Yes, value={0}", value);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", maxDiff);
        }
    }
}