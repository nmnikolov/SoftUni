using System;
using System.Text.RegularExpressions;

//Using loops write a program that converts a hexadecimal integer number to its decimal form. The input is entered as string. 
//The output should be a variable of type long. Do not use the built-in .NET functionality. Examples:
// | hexadecimal |  	decimal |
// | FE	         |          254 |
// | 1AE3        |         6883 |
// | 4ED528CBB4	 | 338583669684 |

class HexadecimalToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter hexadecimal number (may contain only digits from 1 to 9 and letters A, B, C, D, E and F):");
        string input = Console.ReadLine().ToUpper();
        long dec = 0;

        if (!Regex.IsMatch(input, @"^[0-9A-F]+$") || input == "") // using Regex.IsMatch to chech if input contains digits 0-9 and letters A-F
        {
            Console.WriteLine("invalid input");
            return;
        }

        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case 'A': dec += 10 * (long)Math.Pow(16, input.Length - i - 1); break;
                case 'B': dec += 11 * (long)Math.Pow(16, input.Length - i - 1); break;
                case 'C': dec += 12 * (long)Math.Pow(16, input.Length - i - 1); break;
                case 'D': dec += 13 * (long)Math.Pow(16, input.Length - i - 1); break;
                case 'E': dec += 14 * (long)Math.Pow(16, input.Length - i - 1); break;
                case 'F': dec += 15 * (long)Math.Pow(16, input.Length - i - 1); break;
                default: dec += (long)char.GetNumericValue(input[i]) * (long)Math.Pow(16, input.Length - i - 1); break;
            }
        }

        Console.WriteLine(dec);
    }
}