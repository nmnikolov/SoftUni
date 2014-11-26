using System;

//Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time. Examples:
// |   n | Divided by 7 and 5? |
// |   3 |               false |
// |   0 |               false |
// |   5 |               false |
// |   7 |               false |
// |  35 |                true |
// | 140 |                true |

class DivideBy7And5
{
    static void Main()
    {
        Console.Write("Input number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(number != 0 && number % 5 == 0 && number % 7 == 0 ? "Divided by 5 and 7: True" : "Divided by 5 and 7: False");
    }
}