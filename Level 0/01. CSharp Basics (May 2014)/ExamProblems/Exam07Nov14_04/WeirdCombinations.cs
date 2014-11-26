using System;

class WeirdCombinations
{
    static void Main()
    {
        string sequence = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        int count = 0;

        if (n > 3124)
        {
            Console.WriteLine("No");
            return;
        }

        for (int c1 = 0; c1 < 5; c1++)
        {
            for (int c2 = 0; c2 < 5; c2++)
            {
                for (int c3 = 0; c3 < 5; c3++)
                {
                    for (int c4 = 0; c4 < 5; c4++)
                    {
                        for (int c5 = 0; c5 < 5; c5++)
                        {
                            if (count == n)
                            {
                                Console.WriteLine("" + sequence[c1] + sequence[c2] + sequence[c3] + sequence[c4] + sequence[c5]);
                                return;
                            }

                            count++;
                        }
                    }
                }
            }
        }
    }
}