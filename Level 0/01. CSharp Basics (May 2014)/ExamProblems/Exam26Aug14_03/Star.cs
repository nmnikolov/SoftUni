using System;

class Star
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string inner = string.Empty;
        string outer = string.Empty;

        for (int i = 0; i < n / 2; i++)
        {
            outer = new string('.', n - i);
            inner = new string('.', Math.Abs(2 * i - 1));
            if (i == 0)
            {
                Console.WriteLine(outer + "*" + outer);
                continue;
            } 
            Console.WriteLine(outer + "*" + inner + "*" + outer);                      
        }

        Console.WriteLine("{0}{1}{0}", new string('*', n / 2 + 1), new string('.', n - 1));

        for (int i = 1; i < n / 2; i++)
        {
            outer = new string('.', i);
            inner = new string('.', 2 * n - 1 - 2 * i);
            Console.WriteLine("{0}*{1}*{0}", outer, inner);
        }

        for (int i = 0; i < n / 2; i++)
        {
            string middle = new string ('.', n / 2 - 1);
            outer = new string('.', n / 2 - i);

            if (i == 0)
            {               
                Console.WriteLine("{0}*{1}*{1}*{0}", outer, middle);
            }
            else
            {
                inner = new string('.', Math.Abs(2 * i - 1));
                Console.WriteLine("{0}*{1}*{2}*{1}*{0}" ,outer, middle, inner);
            }
        }

        Console.WriteLine("{0}{1}{0}", new string('*', n / 2 + 1), new string('.', n - 1));
    }
}