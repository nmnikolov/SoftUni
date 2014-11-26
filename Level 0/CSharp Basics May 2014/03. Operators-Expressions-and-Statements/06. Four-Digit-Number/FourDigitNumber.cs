using System;

//Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
//•	Calculates the sum of the digits (in our example 2+0+1+1 = 4).
//•	Prints on the console the number in reversed order: dcba (in our example 1102).
//•	Puts the last digit in the first position: dabc (in our example 1201).
//•	Exchanges the second and the third digits: acbd (in our example 2101).
//The number has always exactly 4 digits and cannot start with 0. Examples:
// |      |               |          | last digit | second and third |
// |    n | sum of digits |	reversed |   in front |	digits exchanged |
// | 2011 |             4 |     1102 |	     1201 |	            2101 |
// | 3333 |            12 |     3333 |	     3333 |             3333 |
// | 9876 |            30 |     6789 |	     6987 |	            9786 |

class FourDigitNumber
{
    static void Main()
    {
        Console.Write("Enter 4 digit number: ");
        int number = int.Parse(Console.ReadLine());
        int d = number % 10;
        int c = (number / 10) % 10;
        int b = (number / 100) % 10;
        int a = (number / 1000) % 10;

        //Sum of digits
        Console.WriteLine("Sum of digits: {0}", a + b + c + d); 
            
        //Reverse number
        Console.WriteLine("Reversed: {0}{1}{2}{3}", d, c, b, a);

        //Last digit in front
        Console.WriteLine("Last digit in front: {0}{1}{2}{3}", d, a, b, c);

        //Exchange second and third digits
        Console.WriteLine("Second and third digits exchanged: {0}{1}{2}{3}", a, c, b, d); 
    }
}
