using System;
using System.Collections.Generic;
using System.Linq;

class BiggestTriple
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();

        List<int> numbers = input.Split(' ').Select(int.Parse).ToList();
        List<int> output = new List<int>();
        int maxSum = int.MinValue;
        int sum = 0;

        for (int i = 0; i < numbers.Count - numbers.Count % 3; i += 3)
        {
            sum = numbers[i] + numbers[i + 1] + numbers[i + 2];
            if (sum > maxSum)
            {
                output.Clear();
                output = numbers.GetRange(i, 3).ToList();
                maxSum = sum;                
            }            
        }

        if (numbers.Count % 3 != 0)
        {
            sum = 0;
            for (int i = numbers.Count - numbers.Count % 3; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            if (sum > maxSum)
            {
                output.Clear();
                output = numbers.GetRange(numbers.Count - numbers.Count % 3, numbers.Count % 3).ToList();
            }
        }
        
        Console.WriteLine(string.Join(" ", output));
    }
}