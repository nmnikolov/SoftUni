using System;
using System.Linq;

//We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0. Assume that repeating the same subset several times is not a problem. Examples:
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
        try
        {
            Console.Write("Input sum to check: ");
            int wantedSum = int.Parse(Console.ReadLine());
            Console.Write("Numbers to check: ");
            int numberOfElements = int.Parse(Console.ReadLine());
            Console.Write("Input {0} numbers on a row, separated by a space: ", numberOfElements);
            string number = Console.ReadLine().Trim();
            string[] numbers = number.Split(' ');
            int[] elements = numbers.Select(int.Parse).ToArray();

            int countSum = 0;
            int checkingSum = 0;
            int maxSubsets = (int)Math.Pow(2, numberOfElements) - 1;
            string result = "";
            Console.WriteLine("Result: ");            

            if (elements.Length == numberOfElements)
            {
                for (int i = 1; i <= maxSubsets; i++)
                {
                    for (int j = 0; j <= numberOfElements; j++)
                    {
                        int mask = 1 << j;
                        int nAndMask = i & mask;
                        int bit = nAndMask >> j;
                        if (bit == 1)
                        {
                            checkingSum = checkingSum + elements[j];
                            result += elements[j] + " + ";
                        }
                    }

                    result = result.Trim('+', ' ');
                    result += " = " + wantedSum;

                    if (checkingSum == wantedSum)
                    {
                        Console.WriteLine(result);
                        countSum++;
                    }

                    result = "";
                    checkingSum = 0;
                }
                if (countSum == 0)
                {
                    Console.WriteLine("no zero subset");
                }
            }
            else
            {
                Console.WriteLine("you did not enter exactly {0} numbers", numberOfElements);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("invalid input format");
        }
    }
}