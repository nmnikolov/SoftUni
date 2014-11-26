using System;

//Write an expression that checks for given integer if its third digit from right-to-left is 7. Examples:
// |       n | Third digit 7? |
// |       5 |          false |
// |     701 |	         true |
// |    9703 |           true |
// |     877 |          false |
// |  777877 |          false |
// | 9999799 |           true |

class ThirdDigit
{
    static void Main()
    {
        Console.Write("Input number: ");
        int number = int.Parse(Console.ReadLine());
        number = Math.Abs(number) / 100;
        bool trirdDigit = number % 10 == 7;
        Console.WriteLine("Is third digit 7 from right to left: {0}" , trirdDigit);
    }
}