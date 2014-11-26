using System;

//Write a program that reads 3 real numbers from the console and prints their sum. Examples:
// |   a |	 b |    c |	 sum | 
// |   3 |	 4 |   11 |	  18 |
// |  -2 |	 0 |    3 |	   1 |
// | 5.5 | 4.5 | 20.1 |	30.1 |

class SumThreeNumbers
{
    static void Main()
    {
        Console.Write("Input number for a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Input number for b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Input number for c: ");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("Sum of a + b + c = {0}", a + b + c);
    }
}