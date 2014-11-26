using System;

class Disk
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        int a;
        int b;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                a = j - n / 2;
                b = n / 2 - i;
                if (a * a + b * b <= r * r)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}