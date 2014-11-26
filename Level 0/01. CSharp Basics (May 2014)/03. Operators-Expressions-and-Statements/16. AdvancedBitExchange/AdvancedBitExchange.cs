using System;

//Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer. 
//The first and the second sequence of bits may not overlap. Examples:
// |           n |  p |	 q |  k |          binary representation of n |	                      binary result |       result |
// |  1140867093 |  3 |	24 |  3 | 01000100 00000000 01000000 00010101 |	01000010 00000000 01000000 00100101 |   1107312677 |
// |  4294901775 | 24 |	 3 |  3 | 11111111 11111111 00000000 00001111 |	11111001 11111111 00000000 00111111 |   4194238527 |
// |  2369124121 |  2 |	22 | 10 | 10001101 00110101 11110111 00011001 |	01110001 10110101 11111000 11010001 |   1907751121 |
// |   987654321 |  2 |	 8 | 11 |                                   - |	                                  - |  overlapping |
// |   123456789 | 26 |	 0 |  7 |                                   - |	                                  - | out of range |
// | 33333333333 | -1 |	 0 | 33 |                                   - |	                                  - | out of range |

class AdvancedBitExchange
{
    static void Main()
    {       
        try
        {
            Console.Write("Input n: ");
            uint n = uint.Parse(Console.ReadLine());
            Console.Write("Input p: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Input q: ");
            int q = int.Parse(Console.ReadLine());
            Console.Write("Input k: ");
            int k = int.Parse(Console.ReadLine());
            bool overlapping = Math.Abs(p - q) < k;
            bool outOfRange = p < 0 | q < 0 | p + (k - 1) > 31 | q + (k - 1) > 31;
            if (outOfRange != true && overlapping != true)
            {
                uint firstBits = (n << (32 - p - k)) >> (32 - k);
                uint secondBits = (n << (32 - q - k)) >> (32 - k);
                n = n & ~(firstBits << p) | secondBits << p;
                n = n & ~(secondBits << q) | firstBits << q;
                Console.WriteLine("Result: {0}", n);
                Console.WriteLine("Binary result: {0}", Convert.ToString(n, 2).PadLeft(32, '0'));
            }
            else if (outOfRange == true)
            {
                Console.WriteLine("out of range");
            }
            else
            {
                Console.WriteLine("overlapping");
            }
        }        
        catch (Exception)
        {
            Console.WriteLine("out of range");
        }       
    }
}