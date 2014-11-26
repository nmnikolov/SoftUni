using System;

class BitSifting
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            ulong newNumber = ulong.Parse(Console.ReadLine());
            number = number & ~newNumber;
        }

        int count = 0;
        ulong mask = 0;

        for (int i = 0; i < 64; i++)
        {
            mask = (number >> i) & 1;
            if (mask == 1)
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}