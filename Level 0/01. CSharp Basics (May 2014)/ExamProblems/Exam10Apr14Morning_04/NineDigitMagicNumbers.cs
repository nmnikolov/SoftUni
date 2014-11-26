using System;
using System.Text.RegularExpressions;

class NineDigitMagicNumbers
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());      
        int count = 0;

        for (int i = 111; i <= 777; i++)
        {
            int sumGuess = 0;
            int secondPair = i + diff;
            int thirdPair = secondPair + diff;
            string magicNumber = "" + i + secondPair + thirdPair;

            foreach (var digit in magicNumber)
            {
                sumGuess += (int)Char.GetNumericValue(digit);
            }

            if (sumGuess == sum && Regex.IsMatch(magicNumber, @"^[1-7]+$") && thirdPair <= 777)
            {
                Console.WriteLine(magicNumber);
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No");
        }
    }
}