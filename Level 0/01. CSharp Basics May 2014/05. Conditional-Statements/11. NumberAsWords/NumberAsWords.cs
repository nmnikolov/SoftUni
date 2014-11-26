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

        if (number > 99)
        {
            Console.Write("{0}", HundredsWords(hundredsDigit));
            number = number % 100;  //remove the hundreds
            if (number > 19)
            {
                Console.Write(" and {0}", TensWords(tensDigit).ToLower());
                if (unitsDigit > 0)
                {
                    Console.Write(" {0}", UnitsWords(unitsDigit).ToLower());
                }
            }
            else if (number > 0)
            {
                Console.Write(" and {0}", UnitsWords(number).ToLower());
            }
        }
        else if (number > 19)
        {
            Console.Write("{0}", TensWords(tensDigit));
            if (unitsDigit > 0)
            {
                Console.Write(" {0}", UnitsWords(unitsDigit).ToLower());
            }
        }
        else
        {
            Console.Write("{0}", UnitsWords(number));
        }
        Console.WriteLine();      
    }

    public static string HundredsWords(int n)
    {
        string hundreds = "";
        switch (n)
        {
            case 1: 
                hundreds += "One hundred"; break;
            case 2: 
                hundreds += "Two hundred"; break;
            case 3: 
                hundreds += "Three hundred"; break;
            case 4:
                hundreds += "Four hundred"; break;
            case 5:
                hundreds += "Five hundred"; break;
            case 6:
                hundreds += "Six hundred"; break;
            case 7:
                hundreds += "Seven hundred"; break;
            case 8:
                hundreds += "Eight hundred"; break;
            case 9:
                hundreds += "Nine hundred"; break;
            default:
                break;
        }
        return hundreds;
    }

    public static string TensWords(int n)
    {
        string tens = "";
        switch (n)
        {
            case 2:
                tens += "Twenty"; break;
            case 3:
                tens += "Thirty"; break;
            case 4:
                tens += "Fourty"; break;
            case 5:
                tens += "Fifty"; break;
            case 6:
                tens += "Sixty"; break;
            case 7:
                tens += "Seventy"; break;
            case 8:
                tens += "Eighty"; break;
            case 9:
                tens += "Ninety"; break;
            default:
                break;
        }
        return tens;
    }

    public static string UnitsWords(int n)
    {
        string units = "";
        switch (n)
        {
            case 0:
                units += "Zero"; break;
            case 1:
                units += "One"; break;
            case 2:
                units += "Two"; break;
            case 3:
                units += "Three"; break;
            case 4:
                units += "Four"; break;
            case 5:
                units += "Five"; break;
            case 6:
                units += "Six"; break;
            case 7:
                units += "Seven"; break;
            case 8:
                units += "Eight"; break;
            case 9:
                units += "Nine"; break;
            case 10:
                units += "Ten"; break;
            case 11:
                units += "Eleven"; break;
            case 12:
                units += "Twelve"; break;
            case 13:
                units += "Thirteen"; break;
            case 14:
                units += "Fourteen"; break;
            case 15:
                units += "Fifteen"; break;
            case 16:
                units += "Sixteen"; break;
            case 17:
                units += "Seventeen"; break;
            case 18:
                units += "Eighteen"; break;
            case 19:
                units += "Nineteen"; break;
            default:
                break;
        }
        return units;
    }
}