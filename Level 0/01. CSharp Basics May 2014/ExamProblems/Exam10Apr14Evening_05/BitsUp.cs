using System;

class BitsUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int currentBit = 0;
        int position = 1;

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int j = 7; j >= 0; j--)
            {
                if (currentBit == position)
                {
                    number |= (1 << j);
                    position += step;
                }
                currentBit++;
            }
            Console.WriteLine(number);
        }
    }
}