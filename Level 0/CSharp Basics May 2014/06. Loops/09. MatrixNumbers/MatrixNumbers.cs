using System;

//Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix like in the examples below. 
//Use two nested loops. Examples:
// | n | matrix |    | n | matrix |    | n | matrix  |
// | 2 | 1 2    |    | 3 | 1 2 3  |    | 4 | 1 2 3 4 |
// |   | 2 3    |    |   | 2 3 4  |    |   | 2 3 4 5 |
//                   |   | 3 4 5  |    |   | 3 4 5 6 |
//                                     |   | 4 5 6 7 |

class MatrixNumbers
{
    static void Main()
    {
        Console.Write("Enter integer number n (1 <= n <= 20): ");
        int n;
        bool nParse = int.TryParse(Console.ReadLine(), out n);

        if (!nParse || n < 1 || n > 20)
        {
            Console.WriteLine("invalid input");
            return;
        }

        Console.WriteLine("Matrix:");

        for (int i = 1; i <= n; i++)
        {
            for (int j = i ; j < n + i; j++)
            {
                if (n > 5)
                {
                    Console.Write("{0,-3}", j);
                }
                else
                {
                    Console.Write("{0,-2}", j);
                }              
            }
            Console.WriteLine();
        }
    }
}
