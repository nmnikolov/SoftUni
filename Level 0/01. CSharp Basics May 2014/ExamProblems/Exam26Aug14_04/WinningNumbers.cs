using System;

class WinningNumbers
{
    static void Main()
    {
        string input = Console.ReadLine().ToLower();
        int letSum = 0;
        bool match = false;

        foreach (char c in input)
        {
            letSum += (int)c - 96;
        }

        for (int i = 100; i < 1000; i++)
        {
            int productFirstThree = (i % 10) * (i / 10 % 10) * (i / 100 % 10);

            if (productFirstThree == letSum)
            {
                for (int j = 100; j < 999; j++)
                {
                    int productSecondThree = (j % 10) * (j / 10 % 10) * (j / 100 % 10);

                    if (productFirstThree == productSecondThree )
                    {
                        Console.WriteLine(i + "-" + j);
                        match = true;
                    }                
                }                
            }           
        }

        if (!match)
        {
            Console.WriteLine("No");
        }
    }
}