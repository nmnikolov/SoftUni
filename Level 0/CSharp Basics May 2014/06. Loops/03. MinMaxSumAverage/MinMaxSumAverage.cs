using System;

//Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, the sum and the average of all 
//numbers (displayed with 2 digits after the decimal point). The input starts by the number n (alone in a line) followed by n lines, each holding an integer number. 
//The output is like in the examples below. Examples:
// | input | output       | input | output     |
// |     3 | min = 1      |     2 | min = -1   |
// |     2 | max = 5      |    -1 | max = 4    |
// |     5 | sum = 8      |     4 | sum = 3    |
// |     1 | avg = 2.67   |       | avg = 1.50 |

class MinMaxSumAverage
{
    static void Main()
    {
        Console.Write("Numbers to enter: ");
        int n;
        bool nParse = int.TryParse(Console.ReadLine(), out n);

        if (!nParse || n < 1)
        {
            Console.WriteLine("invalid input");
            return;
        }

        int max = int.MinValue;
        int min = int.MaxValue;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number[{0}]: ", i + 1);
            int number = int.Parse(Console.ReadLine());
            sum += number;

            if (number > max)
            {
                max = number;
            }
            if (number < min)
            {
                min = number;
            }
        }

        Console.WriteLine();
        Console.WriteLine("min = {0}", min);
        Console.WriteLine("max = {0}", max);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("avg = {0:F2}", (double)sum / (double)n);
    }
}