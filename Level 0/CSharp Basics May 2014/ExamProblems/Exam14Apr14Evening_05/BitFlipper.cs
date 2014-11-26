using System;

class BitFlipper
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        int currentBit = 63;
        while (currentBit >= 2)
        {
            ulong bits = n >> (currentBit - 2) & 7; 
            if (bits == 0 || bits == 7)
            {
                n = n ^ ((ulong)7 << currentBit - 2);
                currentBit -= 3;
                continue;
            }
            currentBit--;
        }

        Console.WriteLine(n);
    }
}