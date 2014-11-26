using System;

//Write an expression that checks if given integer is odd or even.
// |  n	|  Odd? |
// |  3	|  true |
// |  2	| false |
// | -2	| false |
// | -1	|  true |
// |  0	| false |

class OddOrEvenIntegers
{
    static void Main()
    {
        Console.Write("Input number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(number % 2 == 0 ? "Odd: false" : "Odd: true");
    }
}