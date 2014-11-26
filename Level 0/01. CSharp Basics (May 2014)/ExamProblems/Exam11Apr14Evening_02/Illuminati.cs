using System;

class Illuminati
{
    static void Main()
    {
        string input = Console.ReadLine().ToLower();
        char[] vowels = {'a', 'e', 'i', 'o', 'u'};
        int[] weight = { 65, 69, 73, 79, 85 };
        int vowelsWeight = 0;
        int count = 0;

        for (int i = 0; i < vowels.Length; i++)
        {
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == vowels[i])
                {
                    vowelsWeight += weight[i];
                    count++;
                }
            }
        }

        Console.WriteLine(count);
        Console.WriteLine(vowelsWeight);
    }
}