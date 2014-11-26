using System;

class ChangeEvenBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int countChanges = 0;
        int len = 1;

        for (int i = 0; i < n; i++)
        {
            string numBinary = Convert.ToString(long.Parse(Console.ReadLine()), 2);
            len = Math.Max(len, numBinary.Length);
        }

        ulong number = ulong.Parse(Console.ReadLine());

        while (len > 0 && n != 0)
        {
            if ((number >> 2 * (len - 1) & 1) == 0)
            {
                number |= (ulong)1 << 2 * (len - 1);
                countChanges++;
            }
            len--;
        }

        Console.WriteLine(number);
        Console.WriteLine(countChanges);
    }
}