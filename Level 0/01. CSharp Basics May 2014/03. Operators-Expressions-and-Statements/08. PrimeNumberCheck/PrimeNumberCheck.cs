using System;

//Write an expression that checks if given positive integer number n (n ≤ 100) is prime (i.e. it is divisible without remainder only to itself and 1). Examples:
// |  n | Prime? |
// |  1 | false  |
// |  2 | true   |
// |  3 | true   |
// |  4 | false  |
// |  9 | false  |
// | 97 | true   |
// | 51 | false  |
// | -3 | false  |
// |  0 | false  |

class PrimeNumberCheck
{
    static void Main()
    {
        Console.Write("Input positive integer number n (0 <= n <= 100): ");
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        if (n >= 0)
        {
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    sum++;
                }
            }
            Console.WriteLine(sum == 2 ? "Prime: true" : "Prime: false");
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
}