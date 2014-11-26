using System;

//Write an if-statement that takes two integer variables a and b and exchanges their values if the first one is greater than the second one. 
//As a result print the values a and b, separated by a space. Examples:
// |   a |   b |  result |
// |   5 |   2 |   2   5 |
// |   3 |   4 |   3   4 |
// | 5.5 | 4.5 | 4.5 5.5 |

class ExchangeIfGreater
{
    static void Main()
    {
        //The third problem example contradicts to the task that's why I am using double variables instead of integer. 
        Console.Write("Input a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Input b: ");
        double b = double.Parse(Console.ReadLine());
        if (a > b)
        {
            a = a + b; 
            b = a - b; 
            a = a - b; 
            Console.WriteLine("{0} {1}", a, b);
        }
        else
        {
            Console.WriteLine("{0} {1}", a, b);
        }
    }
}