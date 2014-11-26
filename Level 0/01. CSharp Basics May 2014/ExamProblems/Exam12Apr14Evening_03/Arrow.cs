using System;

class Arrow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int outer = n / 2;
        int inner = n - 2;
        string outerSpace;
        string innerSpace;

        for (int i = 0; i < n; i++)
        {
            outerSpace = new string('.', outer);
            innerSpace = new string('.', inner);

            if (i == 0)
            {
                innerSpace = new string('#', inner);
            }

            if (i == n - 1)
            {
                outerSpace = new string('#', outer);
            }

            Console.WriteLine(outerSpace + "#" + innerSpace + "#" + outerSpace);
        }

        outer = 1;
        inner = 2 * n - 5;

        for (int i = 0; i < n - 2; i++)
        {
            outerSpace = new string('.', outer);
            innerSpace = new string('.', inner);
            outer++;
            inner -= 2;
            Console.WriteLine(outerSpace + "#" + innerSpace + "#" + outerSpace);
        }

        outerSpace = new string('.', n - 1);

        Console.WriteLine(outerSpace + "#" + outerSpace);
    }
}