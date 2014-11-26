using System;

class NewHouse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int dash = n / 2;
        int asterik = 1;

        for (int i = 0; i < n / 2 + 1; i++)
        {
            string row = new string ('-', dash) + new string ('*', asterik) + new string ('-', dash);
            Console.WriteLine(row);
            dash--;
            asterik += 2;
        }

        for (int i = 0; i < n; i++)
        {
            string row = "|" + new string('*', n - 2) + "|";
            Console.WriteLine(row);
        }
    }
}