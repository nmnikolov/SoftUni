using System;

//Using loops write a program that converts an integer number to its binary representation. The input is entered as long. 
//The output should be a variable of type string. Do not use the built-in .NET functionality. Examples:
// |   decimal |                       binary |
// |         0 |                            0 |
// |         3 |                           11 |
// |     43691 |             1010101010101011 |
// | 236476736 | 1110000110000101100101000000 |

class DecimalToBinary
{
    static void Main()
    {
        Console.Write("Enter integer number n (0 <= n): ");
        long n;
        bool nParse = long.TryParse(Console.ReadLine(), out n);
        string binary = "";

        if (!nParse || n < 0)
        {
            Console.WriteLine("invalid input");
            return;
        }      

        do
        {
            binary = n % 2 + binary;
            n = n / 2;            
        } while (n > 0);

        Console.WriteLine(binary);
    }
}