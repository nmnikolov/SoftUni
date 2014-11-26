using System;

class DoubleDowns
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        int right = 0;
        int left = 0;
        int vertical = 0;

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 31; j >= 0; j--)
            {
                if ((numbers[i] >> j & 1) == 1)
                {
                    if ((numbers[i + 1] >> j - 1 & 1) == 1)
                    {
                        right++;
                    }
                    if ((numbers[i + 1] >> j + 1 & 1) == 1)
                    {
                        left++;
                    }
                    if ((numbers[i + 1] >> j & 1) == 1)
                    {
                        vertical++;
                    }
                }
            }
        }
        Console.WriteLine(right);
        Console.WriteLine(left);
        Console.WriteLine(vertical);
    }
}