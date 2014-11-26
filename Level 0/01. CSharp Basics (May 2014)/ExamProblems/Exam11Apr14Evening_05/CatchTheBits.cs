using System;

class CatchTheBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());      
        int currentBit = 0;
        int position = 1;
        int newNumber = 0;
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int j = 7; j >= 0; j--)
            {
                if (currentBit == position)
                {
                    newNumber = newNumber << 1;
                    newNumber = newNumber ^ (number >> j & 1);
                    position += step;
                    count++;
                }
                currentBit++;
                if (count == 8)
                {
                    Console.WriteLine(newNumber);
                    newNumber = 0;
                    count = 0;
                }
            }
        }

        if (count > 0)
        {
            newNumber <<= (8 - count);
            Console.WriteLine(newNumber);         
        }       
    }
}