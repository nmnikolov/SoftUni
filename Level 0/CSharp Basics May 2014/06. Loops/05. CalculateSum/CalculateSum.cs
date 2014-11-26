using System;
using System.Numerics;

//Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x^2 + … + n!/x^n. Use only one loop. 
//Print the result with 5 digits after the decimal point.
// | n |  x |       S |
// | 3 |  2 | 2.75000 |
// | 4 |  3 | 2.07407 |
// | 5 | -4 | 0.75781 |

class CalculateSum
{
    static void Main()
    {
        Console.Write("Enter integer number n (1 <= n): ");
        int n;
        bool nParse = int.TryParse(Console.ReadLine(), out n);
        Console.Write("Enter integer number x: ");
        int x;
        bool xParse = int.TryParse(Console.ReadLine(), out x);

        if (!nParse || !xParse || n < 1)
        {
            Console.WriteLine("invalid input");
            return;
        }

        double factorial = 1;
        double sum = 1;
        double power = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            sum += (factorial / (x * power));
            power *= x;
        }

        Console.WriteLine("{0:F5}", sum);
    }
}