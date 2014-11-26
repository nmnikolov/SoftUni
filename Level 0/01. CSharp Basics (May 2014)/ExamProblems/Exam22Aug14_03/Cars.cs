using System;

class Cars
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string outer = string.Empty;
        string inner = string.Empty;

        for (int i = 0; i < n / 2; i++)
        {
            outer = new string('.', n - i);
            inner = new string('.', n - 2 + 2 * i);

            if (i == 0)
            {
                inner = new string('*', n);
                Console.WriteLine("{0}{1}{0}", outer, inner, outer);
                continue;
            }

            Console.WriteLine("{0}*{1}*{0}", outer, inner);            
        }

        for (int i = 0; i < n / 2 - 1; i++)
        {
            if (i == 0 )
            {
                outer = new string('*', n / 2 + 1);
                inner = new string('.', 2 * n - 2);

                Console.WriteLine("{0}{1}{0}", outer, inner);
                continue;
            }

            Console.WriteLine("*{0}*", new string('.', 3 * n - 2));
        }

        Console.WriteLine(new string('*', 3 * n));

        for (int i = 0; i < n / 2 - 1; i++)
        {
            outer = new string('.', n / 2);
            inner = new string('.', n - 2);
            string middle = new string('.', n / 2 - 1);

            if (i == n / 2 - 2)
            {
                middle = new string('*', n / 2 + 1);
                Console.WriteLine("{0}{1}{2}{1}{0}", outer, middle, inner);
                continue;
            }

            Console.WriteLine("{0}*{1}*{2}*{1}*{0}", outer, middle, inner);
        }
    }
}