using System;
using System.Collections.Generic;
using System.Linq;

//Write a program to generate the following matrix of palindromes of 3 letters with r rows and c columns:
// | Input | Output 
// |-------|-------------------------|
// | 3 6   | aaa aba aca ada aea afa |
// |       | bbb bcb bdb beb bfb bgb |
// |       | ccc cdc cec cfc cgc chc |
// |-------|-------------------------|
// | 2 3   | aaa aba aca             |
// |       | bbb bcb bdb             |
// |-------|-------------------------|
// | 1 1   | aaa                     |
// |-------|-------------------------|
// | 1 3   | aaa aba aca             |

class MatrixOfPalindromes
{
    static void Main()
    {
        Console.WriteLine("Enter matrix dimensions");
        Console.Write("height: ");
        int height;
        bool heightParse = int.TryParse(Console.ReadLine(), out height);
        Console.Write("width: ");
        int width;
        bool widthParse = int.TryParse(Console.ReadLine(), out width);

        if (!heightParse || !widthParse || height < 1 || width < 1)
        {
            Console.WriteLine("invalid input");
            return;
        }

        string[,] polindromes = new string [height, width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                polindromes[i, j] = "" + (char)('a' + i) + (char)('a' + i + j) + (char)('a' + i);
                Console.Write(polindromes[i, j] + " ");
            }

            Console.WriteLine();
        }       
    }
}
