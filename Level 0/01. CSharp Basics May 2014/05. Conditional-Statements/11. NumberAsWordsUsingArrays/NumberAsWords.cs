using System;

//Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation. Examples:
// | numbers | number as words               |
// |       0 | Zero                          |
// |       9 | Nine                          |
// |      10 | Ten                           |
// |      12 | Twelve                        |
// |      19 | Nineteen                      |
// |      25 | Twenty five                   |
// |      98 | Ninety eight                  |
// |     273 | Two hundred and seventy three |
// |     400 | Four hundred                  |
// |     501 | Five hundred and one          |
// |     617 | Six hundred and seventeen     |
// |     711 | Seven hundred and eleven      |
// |     999 | Nine hundred and ninety nine  |

class NumberAsWords
{
    static void Main()
    {
        //Second method using arrays
        Console.Write("Input number in the range [0...999]: ");
        int number;
        bool parse = int.TryParse(Console.ReadLine(), out number);

        if (!parse || number < 0 || number > 999)
        {
            Console.WriteLine("invalid number");
            return;
        }

        int hundredsDigit = (number / 100) % 10;
        int tensDigit = (number / 10) % 10;
        int unitsDigit = number % 10;

        string[] unitsWords = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] tensWords = { "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        string[] hundredsWords = { "One hundred", "Two hundred", "Three hundred", "Four hundred", "Five hundred", "Six hundred", "Seven hundred", "Eight hundred", "Nine hundred" };

        if (number > 99)
        {
            Console.Write("{0}", hundredsWords[hundredsDigit - 1]);
            number = number % 100;  //remove the hundreds
            if (number > 19)
            {
                Console.Write(" and {0}", tensWords[tensDigit - 2].ToLower());
                if (unitsDigit > 0)
                {
                    Console.Write(" {0}", unitsWords[unitsDigit].ToLower());
                }
            }
            else if (number > 0)
            {
                Console.Write(" and {0}", unitsWords[number].ToLower());
            }
        }
        else if (number > 19)
        {
            Console.Write("{0}", tensWords[tensDigit - 2]);
            if (unitsDigit > 0)
            {
                Console.Write(" {0}", unitsWords[unitsDigit].ToLower());
            }
        }
        else
        {
            Console.Write("{0}", unitsWords[number]);
        }
        Console.WriteLine();
    }
}