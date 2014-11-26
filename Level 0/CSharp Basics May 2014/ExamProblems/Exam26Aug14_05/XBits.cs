using System;

class XBits
{
    static void Main()
    {
        int[] numbers = new int[8];
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                int maskFirstNumber = numbers[i] >> j & 7;
                int maskSecondNumber = numbers[i + 1] >> j & 7;
                int maskThirdNumber = numbers[i + 2] >> j & 7;

                if (maskFirstNumber == 5 && maskSecondNumber == 2 && maskThirdNumber == 5)
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
}