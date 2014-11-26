using System;

class ChessQueens
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine()) + 1;
        bool match = false;

        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (j + d <= n) //check right on row
                {
                    Console.WriteLine("{0}{1} - {2}{3}", (char)('a' + i), j, (char)('a' + i), j + d);
                    Console.WriteLine("{0}{1} - {2}{3}", (char)('a' + i), j + d, (char)('a' + i), j); //print previous row reversed
                    match = true;
                }

                if (i + d < n) //check down on column
                {
                    Console.WriteLine("{0}{1} - {2}{3}", (char)('a' + i), j, (char)('a' + i + d), j);
                    Console.WriteLine("{0}{1} - {2}{3}", (char)('a' + i + d), j, (char)('a' + i), j); //print previous row reversed
                    match = true;
                }

                if (i + d < n && j + d <= n) //check down-right diagonal
                {
                    Console.WriteLine("{0}{1} - {2}{3}", (char)('a' + i), j, (char)('a' + i + d), j + d);
                    Console.WriteLine("{0}{1} - {2}{3}", (char)('a' + i + d), j + d, (char)('a' + i), j); //print previous row reversed
                    match = true;
                }

                if (i + d < n && j - d > 0) //check down-left diagonal
                {
                    Console.WriteLine("{0}{1} - {2}{3}", (char)('a' + i), j, (char)('a' + i + d), j - d);
                    Console.WriteLine("{0}{1} - {2}{3}", (char)('a' + i + d), j - d, (char)('a' + i), j); //print previous row reversed
                    match = true;
                }
            }
        }

        if (!match)
        {
            Console.WriteLine("No valid positions"); 
        }
    }
}