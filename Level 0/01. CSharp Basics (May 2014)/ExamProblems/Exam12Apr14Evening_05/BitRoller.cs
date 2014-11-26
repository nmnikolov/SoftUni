using System;

class BitRoller
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int f = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        int fBit = (n >> f) & 1;
        int bit0 = 0;
        int bitLeftF = 0;

        for (int i = 0; i < r; i++)
        {
            if (f > 0 && f < 18)
            {
                bit0 = n & 1;
                bitLeftF = (n >> (f + 1)) & 1;                 
                n >>= 1;
                n = n & (~(1 << f)) | (fBit << f);
                n = n & (~(1 << 18)) | (bit0 << 18);
                n = n & (~(1 << (f - 1))) | (bitLeftF << (f - 1));
            }
            else if (f == 18)
            {
                bitLeftF = n & 1;
                n >>= 1;
                n = n & (~(1 << f)) | (fBit << f);
                n = n & (~(1 << 17)) | (bitLeftF << 17);
            }
            else if (f == 0)
            {
                bitLeftF = (n >> 1) & 1;
                n >>= 1;
                n = n & (~(1 << f)) | (fBit << f);
                n = n & (~(1 << 18)) | (bitLeftF << 18);
            }
                    
        }
        Console.WriteLine(n);      
    }
}