using System;

class OddEvenCounter
{
    static void Main()
    {
        int sets = int.Parse(Console.ReadLine());
        int numbers = int.Parse(Console.ReadLine());
        string typeToCount = Console.ReadLine();

        int maxCount = 0;
        int count = 0;
        int set = 0;

        for (int i = 0; i < sets; i++)
        {
            for (int j = 0; j < numbers; j++)
            {
                int number = int.Parse(Console.ReadLine());

                if (typeToCount == "even" && number % 2 == 0)
                {
                    count++;
                }
                else if (typeToCount == "odd" && number % 2 != 0)
                {
                    count++;
                }
            }

            if (count > maxCount)
            {
                set = i + 1;
                maxCount = count;
            }

            count = 0;
        }

        if (maxCount != 0)
        {
            string digit = "";
            switch (set)
            {
                case 1: digit = "First"; break;
                case 2: digit = "Second"; break;
                case 3: digit = "Third"; break;
                case 4: digit = "Fourth"; break;
                case 5: digit = "Fifth"; break;
                case 6: digit = "Sixth"; break;
                case 7: digit = "Seventh"; break;
                case 8: digit = "Eighth"; break;
                case 9: digit = "Ninth"; break;
                case 10: digit = "Tenth"; break;
            }

            Console.WriteLine("{0} set has the most {1} numbers: {2}", digit, typeToCount, maxCount);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}