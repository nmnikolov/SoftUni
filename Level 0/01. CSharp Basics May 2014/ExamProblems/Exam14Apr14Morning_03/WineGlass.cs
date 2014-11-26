using System;

class WineGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int wine = n / 2;
        int stem = n >= 12 ? n / 2 - 2 : n / 2 - 1;
        int bottom = n - n / 2 - stem;

        for (int i = 0; i < wine; i++) // Print the part with the wine
        {
            string dot = new string ('.', i);
            string asterik = new string('*', n - 2 - i * 2);
            Console.WriteLine(dot + "\\" + asterik + "/" + dot);
        }

        for (int i = 0; i < stem; i++) // Print the stem
        {
            string dot = new string('.', n / 2 - 1);
            Console.WriteLine(dot + "||" + dot);
        }

        for (int i = 0; i < bottom ; i++) // Print the bottom
        {
            Console.WriteLine(new string('-', n));
        }
    }
}