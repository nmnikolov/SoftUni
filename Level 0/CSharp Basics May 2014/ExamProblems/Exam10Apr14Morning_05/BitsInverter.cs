using System;

class BitsInverter
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int position = 0;
        int currentBit = 0;

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int j = 7; j >= 0; j--)
            {
                if (currentBit == position)
                {
                    number = number ^ (1 << j);
                    position += step;
                }                
                currentBit++;
            }
            Console.WriteLine(number);            
        }       
    }
}