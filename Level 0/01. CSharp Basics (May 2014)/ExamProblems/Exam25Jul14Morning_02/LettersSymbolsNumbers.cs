using System;

class LettersSymbolsNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int letters = 0;
        int numbers = 0;
        int symbols = 0;
        string input = string.Empty;

        for (int i = 0; i < n; i++)
        {
            input += string.Join("", Console.ReadLine().ToLower().Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
        }

        foreach (char ch in input)
        {
            if (char.IsLetter(ch))
            {
                letters += (ch - 96) * 10;
            }
            else if (char.IsDigit(ch))
            {
                numbers += (int)char.GetNumericValue(ch) * 20;
            }
            else
            {
                symbols += 200;
            }
        }

        Console.WriteLine(letters);
        Console.WriteLine(numbers);
        Console.WriteLine(symbols);
    }
}