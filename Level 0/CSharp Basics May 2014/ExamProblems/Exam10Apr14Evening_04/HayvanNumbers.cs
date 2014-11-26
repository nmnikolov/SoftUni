using System;
using System.Text.RegularExpressions;

class HayvanNumbers
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        int count = 0;

        for (int i = 555; i <= 999; i++)
        {
            int sumGuess = 0;
            int secondPair = i + diff;
            int thirdPair = secondPair + diff;
            string number = "" + i + secondPair + thirdPair;
            
            foreach (var digit in number)
            {
                sumGuess += (int)Char.GetNumericValue(digit);
            }

            if ( sumGuess == sum && Regex.IsMatch(number, @"^[5-9]+$") && thirdPair <= 999)
            {
                Console.WriteLine(number);
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No");          
        }
    }   
}