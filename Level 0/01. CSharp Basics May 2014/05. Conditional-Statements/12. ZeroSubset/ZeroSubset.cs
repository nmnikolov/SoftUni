using System;

//We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0. Assume that repeating the same subset several times is not a problem. Examples:
// numbers	result
//  _______________________________________
// |numbers        | result                |
// |---------------|-----------------------|
// | 3 -2  1  1  8 | -2 + 1 + 1 = 0        |
// |---------------|-----------------------|
// | 3  1 -7 35 22 | no zero subset        |
// |---------------|-----------------------|
// | 1  3 -4 -2 -1 | 1 + -1 = 0            |
// |               | 1 + 3 + -4 = 0        |
// |               | 3 + -2 + -1 = 0       |
// |---------------|-----------------------|
// | 1  1  1 -1 -1 | 1 + -1 = 0            |
// |               | 1 + 1 + -1 + -1 = 0   |
// |               | 1 + -1 + 1 + -1 = 0   |
// |               | …                     |
// |---------------|-----------------------| 
// | 0  0  0  0  0 | 0 + 0 + 0 + 0 + 0 = 0 |
// |_______________|_______________________|
//
//Hint: you may check for zero each of the 32 subsets with 32 if statements.

class ZeroSubset
{
    static void Main()
    {
        Console.Write("Input number a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Input number b: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Input number c: ");
        int c = int.Parse(Console.ReadLine());
        Console.Write("Input number d: ");
        int d = int.Parse(Console.ReadLine());
        Console.Write("Input number e: ");
        int e = int.Parse(Console.ReadLine());
        int countSum = 0;
        
        //a
        if (a == 0)
        {
            Console.WriteLine("{0} = 0", a);
            countSum++;
        }
        if (a + b == 0)
        {
            Console.WriteLine("{0} + {1} = 0", a, b);
            countSum++;
        }
        if (a + c == 0)
        {
            Console.WriteLine("{0} + {1} = 0", a, c);
            countSum++;
        }
        if (a + d == 0)
        {
            Console.WriteLine("{0} + {1} = 0", a, d);
            countSum++;
        }
        if (a + e == 0)
        {
            Console.WriteLine("{0} + {1} = 0", a, e);
            countSum++;
        }
        if (a + b + c == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", a, b, c);
            countSum++;
        }
        if (a + b + d == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", a, b, d);
            countSum++;
        }
        if (a + b + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", a, b, e);
            countSum++;
        }
        if (a + c + d == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", a, c, d);
            countSum++;
        }
        if (a + c + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", a, c, e);
            countSum++;
        }
        if (a + d + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", a, d, e);
            countSum++;
        }
        if (a + b + c + d == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, c, d);
            countSum++;
        }
        if (a + b + c + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, c, e);
            countSum++;
        }
        if (a + b + d + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, d, e);
            countSum++;
        }
        if (a + c + d + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, c, d, e);
            countSum++;
        }
        if (a + b + c + d + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", a, b, c, d, e);
            countSum++;
        }      
 
        //b
        if (b == 0)
        {
            Console.WriteLine("{0} = 0", b);
            countSum++;
        }
        if (b + c == 0)
        {
            Console.WriteLine("{0} + {1} = 0", b, c);
            countSum++;
        }
        if (b + d == 0)
        {
            Console.WriteLine("{0} + {1} = 0", b, d);
            countSum++;
        }
        if (b + e == 0)
        {
            Console.WriteLine("{0} + {1} = 0", b, e);
            countSum++;
        }
        if (b + c + d == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", b, c, d);
            countSum++;
        }
        if (b + c + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", b, c, e);
            countSum++;
        }    
        if (b + d + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", b, d, e);
            countSum++;
        }              
        if (b + c + d + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", b, c, d, e);
            countSum++;
        }    

        //c
        if (c == 0)
        {
            Console.WriteLine("{0} = 0", c);
            countSum++;
        }
        if (c + d == 0)
        {
            Console.WriteLine("{0} + {1} = 0", c, d);
            countSum++;
        }
        if (c + d + e == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", c, d, e);
            countSum++;
        }
        if (c + e == 0)
        {
            Console.WriteLine("{0} + {1} = 0", c, e);
            countSum++;
        }

        //d
        if (d == 0)
        {
            Console.WriteLine("{0} = 0", d);
            countSum++;
        }
        if (d + e == 0)
        {
            Console.WriteLine("{0} + {1} = 0", d, e);
            countSum++;
        }

        //e
        if (e == 0)
        {
            Console.WriteLine("{0} = 0", e);
            countSum++;
        }

        if (countSum == 0)
        {
            Console.WriteLine("no zero subset");
        }
    }
}
