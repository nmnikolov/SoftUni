using System;
using System.Numerics;

//Define a method Fib(n) that calculates the nth Fibonacci number. Examples:
// |  n | Fib(n) |
// |  0 |      1 |
// |  1 |      1 |
// |  2 |      2 |
// |  3 |      3 |
// |  4 |      5 |
// |  5 |      8 |
// |  6 |     13 |
// | 11 |    144 |
// | 25 | 121393 |

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("Enten integer number n (0 <= n): ");
        int n;
        bool numberParse = int.TryParse(Console.ReadLine(), out n);

        if (numberParse && n >= 0)
        {
            Console.WriteLine(Fib(n));
        }
        else
        {
            Console.WriteLine("invalid input");
        }
    }

    static BigInteger Fib(int n)
    {
        BigInteger x1 = 0;
        BigInteger x2 = 1;

        for (int i = 0; i < n; i++)
        {
            x2 = x2 + x1;
            x1 = x2 - x1;
        }

        return x2;
    }
}