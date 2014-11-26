using System;
using System.Linq;

class JumpingSums
{
    static void Main()
    {
        int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int jumps = int.Parse(Console.ReadLine());
        int maxSum = int.MinValue;
        
        for (int i = 0; i < inputArray.Length; i++)
        {
            int index = i;
            int sum = inputArray[index];
            for (int j = 0; j < jumps; j++)
            {
                index = (index + inputArray[index]) % inputArray.Length;
                sum += inputArray[index];
            }
            maxSum = Math.Max(maxSum, sum);
        }
        Console.WriteLine("max sum = {0}", maxSum);
    }
}