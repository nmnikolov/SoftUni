using System;

//Write a program that calculates with how many zeroes the factorial of a given number n has at its end. Your program should work well for very big numbers, e.g. n=100000. Examples:
// |      n | trailing zeroes of n! | explaination        |
// |     10 |                     2 | 3628800             |
// |     20 |                     4 | 2432902008176640000 |
// | 100000 |                 24999 | think why           |

class TrailingZeroes
{
    static void Main()
    {
        Console.Write("Enter integer number n (0 <= n): ");
        long n;
        bool nParse = long.TryParse(Console.ReadLine(), out n);

        if (!nParse || n < 0)
        {
            Console.WriteLine("invalid input");
            return;
        }

        long trailinZeroes = 0;
        int power = 1;

        do
        {
            trailinZeroes += n / (long)Math.Pow(5, power);
            power++;
            
        } while (Math.Pow(5, power) <= n);

        Console.WriteLine(trailinZeroes);       
    }
}