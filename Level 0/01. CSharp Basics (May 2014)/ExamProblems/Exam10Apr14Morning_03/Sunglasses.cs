using System;

class Sunglasses
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string frame = "*" + new string('/', 2 * n - 2) + "*";
        string connection = new string('|', n);
        string midlle = new string(' ', n); 

        Console.WriteLine(new string('*', 2 * n) + new string(' ', n) + new string('*', 2 * n));

        for (int i = 0; i < n - 2; i++)
        {
            if (i == (n - 2) / 2)
            {
                Console.WriteLine(frame + connection + frame);
            }
            else
            {
                Console.WriteLine(frame + midlle + frame);
            }
        }

        Console.WriteLine(new string('*', 2 * n) + new string(' ', n) + new string('*', 2 * n));
    }
}