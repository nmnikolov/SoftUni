using System;

//Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:
//    ©
//   © ©
//  ©   ©
// © © © ©
//Note that the © symbol may be displayed incorrectly at the console so you may need to change the console character encoding to UTF-8 and assign a Unicode-friendly font 
//in the console. Note also, that under old versions of Windows the © symbol may still be displayed incorrectly, regardless of how much effort you put to fix it.

class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Read from the console the number of the rows
        Console.WriteLine("Enter number of rows:");
        int rows = int.Parse(Console.ReadLine());
        Console.Clear();      
        char sign = '\u00A9';     
        int innerSpace = 1;
        int outerSpace;
        for (int i = 0; i < rows; i++)
        {
            if (i == 0) //Print the first row
            {
                Console.WriteLine(new string(' ', rows - 1) + sign);
            }
            else if (i == rows - 1) // Print the last row
            {
                for (int n = 1; n <= rows; n++)
                {
                    Console.Write("{0} ", sign);
                }
                Console.WriteLine();                
            }
            else //Print all rows except first and last one
            {
                outerSpace = (rows - 1) - i;
                Console.Write(new string(' ', outerSpace));
                Console.Write(sign);
                Console.Write(new string(' ', innerSpace));
                Console.WriteLine(sign);
                innerSpace += 2;
            }            
        }    
    }
}