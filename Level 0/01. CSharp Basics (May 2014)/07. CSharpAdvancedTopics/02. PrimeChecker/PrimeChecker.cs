using System;

//Write a Boolean method IsPrime(n) that check whether a given integer number n is prime. Examples:
// |            n | IsPrime(n) |
// |            0 | false      |
// |            1 | false      |
// |            2 | true       |
// |            3 | true       |
// |            4 | false      |
// |            5 | true       |
// |          323 | false      |
// |          337 | true       |
// |   6737626471 | true       |
// | 117342557809 | false      |

class PrimeChecker
{
    static void Main()
    {
        Console.Write("Enten integer number n (0 <= n): ");
        long number;
        bool numberParse = long.TryParse(Console.ReadLine(), out number);

        if (numberParse && number >= 0)
        {
            Console.WriteLine(IsPrime(number));
        }
        else
        {
            Console.WriteLine("invalid input");
        }
    }

    static bool IsPrime(long n)
    {
        if (n == 0 || n == 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
