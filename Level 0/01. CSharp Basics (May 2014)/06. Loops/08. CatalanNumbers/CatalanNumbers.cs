using System;
using System.Numerics;

//Write a program to calculate the nth Catalan number   (2n)! / (n + 1)! * n!   by given n (1 < n < 100).  Examples:
// |  n | Catalan(n) |
// |  0 |          1 |
// |  5 |         42 |
// | 10 |      16796 |
// | 15 |    9694845 |

class CatalanNumbers
{
    static void Main()
    {
        //The first problem example contradicts to the task that's why when the user enters 0 the program will return "invalid input"
        Console.Write("Enter integer number (1 < n < 100): ");
        int n;
        bool nParse = int.TryParse(Console.ReadLine(), out n);

        if (!nParse || n <= 1 || n >= 100)
        {
            Console.WriteLine("invalid input");
            return;
        }

        BigInteger factorial2N = 1;
        BigInteger factorialN1 = 1;
        BigInteger factorialN = 1;

        for (int i = 1; i <= 2 * n; i++)
        {
            if (i <= n)
            {
                factorialN *= i;
            }
            if (i <= n + 1)
            {
                factorialN1 *= i;
            }
            factorial2N *= i;
        }

        BigInteger catalan = factorial2N / (factorialN1 * factorialN);
        Console.WriteLine(catalan);    
    }
}