using System;
using System.Collections.Generic;
using System.Linq;

class SequenceOfKNumbers
{
    static void Main()
    {
        string[] sequence = Console.ReadLine().Trim().Split(' ');
        
        int k = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();

        for (int i = 0; i < sequence.Length; i++)
        {
            list.Add(int.Parse(sequence[i]));
        }

        bool check = true;
        int element = 0;

        while (element <= list.Count - k)
        {        
            for (int i = 0; i < k - 1; i++)
            {
                if (list[element + i] != list[element + i + 1])
                {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                for (int p = 0; p < k; p++)
                {
                    list.Remove(list[element]);
                }
                element = 0;
                check = true;
            }
            else
            {
                element++;
                check = true;
            }
            
        }
    
        Console.WriteLine(string.Join(" ", list));
    }
}