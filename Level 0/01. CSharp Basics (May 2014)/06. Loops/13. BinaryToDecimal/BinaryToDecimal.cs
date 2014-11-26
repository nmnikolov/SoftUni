using System;
using System.Text.RegularExpressions;

//Using loops write a program that converts a binary integer number to its decimal form. The input is entered as string. 
//The output should be a variable of type long. Do not use the built-in .NET functionality. Examples:
// |                        binary |   decimal |
// |                            0  |         0 |
// |                           11  |         3 |
// |             1010101010101011  |     43691 |
// | 1110000110000101100101000000  | 236476736 |

class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter binary integer number (contains only 0 and 1): ");
        string input = Console.ReadLine().Trim();
        long dec = 0;

        if (!Regex.IsMatch(input, @"^[0-1]+$") || input == "")  // using Regex.IsMatch to chech if input contains only '0' and '1'
        {
            Console.WriteLine("invalid input");
            return;
        }

        for (int i = 0; i < input.Length; i++)
        {
            if (input[input.Length - i - 1] == '1')
            {
                dec += (long)Math.Pow(2, i);
            }
        }

        Console.WriteLine(dec);
    }
}