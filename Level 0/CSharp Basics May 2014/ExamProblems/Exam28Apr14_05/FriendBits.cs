using System;

class FriendBits
{
    static void Main()
    {
        uint n = UInt32.Parse(Console.ReadLine());
        uint friendBits = 0;
        uint aloneBits = 0;

        for (int i = 31; i >= 0 ; i--)
        {
            uint leftBit = n >> (i + 1) & 1;
            uint rightBit = n >> (i - 1) & 1;
            uint currentBit = n >> i & 1;

            if ((currentBit == leftBit && i < 31) || (currentBit == rightBit && i > 0))
            {
                friendBits = friendBits << 1 | currentBit;
            }
            else
	        {
                aloneBits = aloneBits << 1 | currentBit;
	        }         
        }
        Console.WriteLine(friendBits);
        Console.WriteLine(aloneBits);
    }  
}