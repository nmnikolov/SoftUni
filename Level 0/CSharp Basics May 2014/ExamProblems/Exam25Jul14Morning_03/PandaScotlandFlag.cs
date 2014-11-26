using System;

class PandaScotlandFlag
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string outer = string.Empty;
        string inner = string.Empty;
        char leftLetter = 'A';
        char rightLetter = 'B';

        for (int i = 0; i < n; i++)
        {            
            if (i < n / 2)
            {
                outer = new string('~', i);
                inner = new string('#', n - 2 - 2 * i);
                Console.WriteLine(outer + leftLetter + inner + rightLetter + outer);
            }

            if (i == n / 2)
            {
                outer = new string('-', (n - 1) / 2);
                Console.WriteLine(outer + leftLetter + outer);
                leftLetter--;
            }

            if (i > n / 2)
            {
                outer = new string('~', n % i - 1);
                inner = new string('#', 2 * i - n);
                Console.WriteLine(outer + leftLetter + inner + rightLetter + outer);
            }
            
            leftLetter = CheckLetter((char)(leftLetter + 2));
            rightLetter = CheckLetter((char)(leftLetter + 1));
        }
    }

    public static char CheckLetter(char letter)
    {
        if (letter > 'Z')
        {
            letter = (char)(letter - 26);
        }
        return letter;
    }
}