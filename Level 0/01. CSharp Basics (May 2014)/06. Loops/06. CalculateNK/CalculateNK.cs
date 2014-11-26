using System;
using System.Numerics;

//Write a program that calculates n! / k! for given n and k (1 < k < n < 100). Use only one loop. Examples:
// | n | k | n! / k! |
// | 5 | 2 |      60 |
// | 6 | 5 |       6 |
// | 8 | 3 |    6720 |

class CalculateNK
{
    static void Main()
    {
        Console.WriteLine("Enter integer n and k  (1 < k < n < 100)");
        Console.Write("n: ");
        int n;
        bool nParse = int.TryParse(Console.ReadLine(), out n);
        Console.Write("k: ");
        int k;
        bool kParse = int.TryParse(Console.ReadLine(), out k);

        if (!nParse || !kParse || k >= n || k <= 1 || k >= 100 || n <= 1 || n >= 100)
        {
            Console.WriteLine("invalid input");
            return;
        }

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;

        for (int i = 1; i <= n; i++)
        {
            if (i <= k)
            {
                factorialK *= i;
            }
            factorialN *= i;
        }

        Console.WriteLine(factorialN / factorialK);
    }
}