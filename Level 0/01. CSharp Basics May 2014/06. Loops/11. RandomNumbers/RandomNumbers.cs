using System;

//Write a program that enters 3 integers n, min and max (min ≤ max) and prints n random numbers in the range [min...max]. Examples:
// |  n | min | max | random numbers                |
// |  5 |   0 |   1 | 1 0 0 1 1                     |
// | 10 |  10 |  15 | 12 14 12 15 10 12 14 13 13 11 |
//Note that the above output is just an example. Due to randomness, your program most probably will produce different results.

class RandomNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter integer n, min and max (1 <= n) (min <= max)");
        Console.Write("Enter n: ");
        int n;
        bool nParse = int.TryParse(Console.ReadLine(), out n);
        Console.Write("Enter min: ");
        int min;
        bool minParse = int.TryParse(Console.ReadLine(), out min);
        Console.Write("Enter max: ");
        int max;
        bool maxParse = int.TryParse(Console.ReadLine(), out max);

        if (!nParse || !minParse || !maxParse || n < 1 || min > max)
        {
            Console.WriteLine("invalid input");
            return;
        }

        Random random = new Random();
        string output = "";

        for (int i = 0; i < n; i++)
        {
            int number = random.Next(min, max + 1);
            output += number + " ";
        }

        Console.WriteLine(output.Trim());
    }
}