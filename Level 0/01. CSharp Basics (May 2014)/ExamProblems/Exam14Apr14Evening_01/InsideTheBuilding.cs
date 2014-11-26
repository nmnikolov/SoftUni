using System;

class InsideTheBuilding
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());

        for (int i = 0; i < 5; i++)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool insideBottom = x >= 0 && x <= 3 * h && y >= 0 && y <= h;
            bool insideTop = x >= h && x <= 2 * h && y >= 0 && y <= 4 * h;

            if (insideBottom || insideTop)
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}