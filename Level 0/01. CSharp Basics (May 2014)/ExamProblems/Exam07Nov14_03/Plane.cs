using System;

class Plane
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int inner = 1;
        int outer;

        Console.WriteLine("{0}*{0}", new string('.', 3 * n / 2));

        for (int i = 0; i < n; i++)
        {
            outer = (3 * n - 2 - inner) / 2;
            Console.WriteLine("{0}*{1}*{0}", new string('.', outer), new string('.', inner));
            inner += 2;

            if (i > n - n / 2 - 1)
            {
                inner += 2;
            }
        }

        Console.WriteLine("*{0}*{1}*{0}*", new string('.', n - 2), new string('.', n));
        outer = n - 4;
        inner = 1;

        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', outer), new string('.', inner), new string('.', n));
            inner += 2;
            outer -= 2;
        }

        inner = n;

        for (int i = 0; i < n - 1; i++)
        {
            outer = (3 * n - 2 - inner) / 2;
            Console.WriteLine("{0}*{1}*{0}", new string('.', outer), new string('.', inner));
            inner += 2;
        }

        Console.WriteLine(new string('*', 3 * n));
    }
}