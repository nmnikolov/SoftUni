using System;

class BitKiller
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int position = 1;
        int currentBit = 0;
        int newNumber = 0;
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int bit = 7; bit >= 0 ; bit--)
            {
                if (currentBit == position)
                {
                    position += step;
                }
                else
                {
                    newNumber <<= 1;
                    newNumber |= (number >> bit & 1);
                    count++;
                }               

                if (count == 8)
	            {
                    Console.WriteLine(newNumber);
		            count = 0;
                    newNumber = 0;
	            }
                currentBit++;
            }
        }

        if (count > 0)
        {
            newNumber <<= (8 - count);
            Console.WriteLine(newNumber);
        }
    }
}