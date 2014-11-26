using System;

//Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n has value of 1. Examples:
// |     n | binary representation of n |  p | bit @ p == 1 |
// |     5 |          00000000 00000101 |  2 |         true |
// |     0 |          00000000 00000000 |  9 |        false |
// |    15 |          00000000 00001111 |  1 |         true |
// |  5343 |          00010100 11011111 |  7 |         true |
// | 62241 |          11110011 00100001 | 11 |        false |

class CheckBitGivenPosition
{
    static void Main()
    {
        Console.Write("Input number: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Input bit position: ");
        int p = int.Parse(Console.ReadLine());
        int mask = n >> p;
        bool checkBit = (mask & 1) == 1 ? true : false;
        Console.WriteLine("Bit #{0} = 1: {1}", p, checkBit);
        Console.Write("Binary representation: ");
        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
    }
}