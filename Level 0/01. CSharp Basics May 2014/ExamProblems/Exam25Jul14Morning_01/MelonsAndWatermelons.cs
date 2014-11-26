using System;

class MelonsAndWatermelons
{
    static void Main()
    {
        int s = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int watermelons = 0;
        int melons = 0;

        for (int i = 0; i < d; i++)
        {
            switch (s)
            {
                case 1:
                    watermelons++;
                    break;
                case 2:
                    melons += 2;
                    break;
                case 3:
                    watermelons++;
                    melons++;
                    break;
                case 4:
                    watermelons += 2;
                    break;
                case 5:
                    watermelons += 2;
                    melons += 2;
                    break;
                case 6:
                    watermelons++;
                    melons += 2;
                    break;
            }
            s = ++s == 8 ? 1 : s;
        }

        if (watermelons == melons)
        {
            Console.WriteLine("Equal amount: {0}", watermelons);
        }
        else if (watermelons > melons)
        {
            Console.WriteLine("{0} more watermelons", watermelons - melons);
        }
        else
        {
            Console.WriteLine("{0} more melons", melons - watermelons);
        }
    }
}