using System;
using System.Collections.Generic;
using System.Linq;

class NakovsMatching
{
    static void Main()
    {
        List<char> a = Console.ReadLine().Select(c => c).ToList();
        List<char> b = Console.ReadLine().Select(c => c).ToList();
        int d = int.Parse(Console.ReadLine());
        bool match = false;
        int nakovs = 0;

        for (int a1 = 1; a1 < a.Count; a1++)
        {
            for (int b1 = 1; b1 < b.Count; b1++)
            {
                string aLeft = string.Join("", a.GetRange(0, a1));
                string aRight = string.Join("", a.GetRange(a1, a.Count - a1));
                string bLeft = string.Join("", b.GetRange(0, b1));
                string bRight = string.Join("", b.GetRange(b1, b.Count - b1));

                nakovs = Math.Abs(CalculateWeight(aLeft) * CalculateWeight(bRight) - CalculateWeight(aRight) * CalculateWeight(bLeft));

                if (nakovs <= d)
                {                  
                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs", aLeft, aRight, bLeft, bRight, nakovs);
                    match = true;
                }
            }                              
        }

        if (!match)
        {
            Console.WriteLine("No");
        }
    }

    public static int CalculateWeight (string word)
    {
        int weight = 0;
        foreach (char ch in word)
        {
            weight += (int)ch;
        }
        return weight;
    }
}