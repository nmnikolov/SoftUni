using System;
using System.Numerics;

//In combinatorics, the number of ways to choose k different members out of a group of n different elements (also known as the number of combinations) is 
//calculated using a formula. For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards. 
//Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops. Examples:
// | n | k | n! / (k! * (n-k)!) |
// | 3 | 2 |                  3 |
// | 4 | 2 |                  6 |
// |10 | 6 |                210 |
// |52 | 5 |            2598960 |

class CalculateNK
{
    static void Main()
    {
        Console.WriteLine("Enter integer numbers n and k (1 < k < n < 100)");
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
        BigInteger factorialNK = 1;
        
        for (int i = 1; i <= n; i++)
        {
            if (i <= k)
            {
                factorialK *= i;
            }
            if (i <= n - k)
            {
                factorialNK *= i;
            }
            factorialN *= i;
        }
       
        BigInteger combination = factorialN / (factorialK * factorialNK);
        Console.WriteLine(combination);
    }
}