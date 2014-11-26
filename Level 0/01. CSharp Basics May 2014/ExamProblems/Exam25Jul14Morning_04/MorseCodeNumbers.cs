using System;

class MorseCodeNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] morse = { "-----", ".----", "..---", "...--", "....-", "....." };
        bool match = false;
        int nSum = 0;
        int product;

        for (int i = 0; i < 4; i++)
        {
            nSum += n % 10;
            n = n / 10;
        }

        for (int a = 0; a < 6; a++)
        {
            for (int b = 0; b < 6; b++)
            {
                for (int c = 0; c < 6; c++)
                {
                    for (int d = 0; d < 6; d++)
                    {
                        for (int e = 0; e < 6; e++)
                        {
                            for (int f = 0; f < 6; f++)
                            {
                                product = a * b * c * d * e * f;
                                if (product == nSum)
                                {
                                    Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|", morse[a], morse[b], morse[c], 
                                                                                  morse[d], morse[e], morse[f]);
                                    match = true;
                                }
                            }
                        }
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