using System;

class HouseWithAWindow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string outerDots = string.Empty;
        string innerDots = string.Empty;
        string window = new string ('*', n - 3);

        for (int i = 0; i < n; i++)
        {
            outerDots = new string('.', n - 1 - i);
           
            if (i == 0)
            {
                Console.WriteLine(outerDots + '*' + outerDots);
                continue;
            }

            innerDots = new string('.', 2 * i - 1);
            Console.WriteLine(outerDots + '*' + innerDots + '*' + outerDots);
        }

        for (int i = 0; i < n + 2; i++)
        {
            if (i == 0 || i == n + 1)
            {
                Console.WriteLine(new string('*', 2 * n - 1));
                continue;
            }

            if (i >= n / 4 + 1 && i < 3 * n / 4 + 1)
            {
                outerDots = new string ('.', n / 2);
                Console.WriteLine('*' + outerDots + window + outerDots + '*');
                continue;
            }

            innerDots = new string('.', 2 * n - 3);
            Console.WriteLine('*' + innerDots + '*');
        }
    }
}