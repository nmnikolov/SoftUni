using System;

class TheExplorer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(new string('-', n / 2) + "*" + new string('-', n / 2));
        int outDash = n / 2;
        int intDash = 1;
        string outDashes;
        string intDashes;

        for (int i = 0; i < n - 2; i++)
        {
            if (i == (n - 2) / 2 + 1)
            {
                intDash -= 2;
            }
            if (i > (n - 2) / 2)
            {
                intDash -= 2;
                outDashes = new string('-', ++outDash);
                intDashes = new string('-', intDash);
                Console.WriteLine(outDashes + "*" + intDashes + "*" + outDashes);
                continue;
            }
            outDashes = new string('-', --outDash);
            intDashes = new string('-', intDash);
            Console.WriteLine(outDashes + "*" + intDashes + "*" + outDashes);
            intDash += 2;
        }

        Console.WriteLine(new string('-', n / 2) + "*" + new string('-', n / 2));
    }
}