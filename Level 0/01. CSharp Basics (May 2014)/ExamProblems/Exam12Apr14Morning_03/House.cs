using System;

class House
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int outerDots = n / 2 - 1;
        int innerDots = 1;
        string outer = "";
        string inner = "";

        Console.WriteLine(new string('.', n / 2) + "*" + new string('.', n / 2));

        for (int i = 0; i < n / 2 - 1; i++)
        {
            outer = new string('.', outerDots);
            inner = new string('.', innerDots);
            Console.WriteLine(outer + "*" + inner + "*" + outer);
            outerDots--;
            innerDots += 2;
        }

        Console.WriteLine(new string ('*', n));
        outer = new string('.', n / 4);
        inner = new string('.', n - 2 - 2 * (n / 4));

        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine(outer + "*" + inner + "*" + outer);
        }
   
        inner = new string ('*', n - 2 * (n / 4));
        Console.WriteLine(outer + inner + outer);
    }
}