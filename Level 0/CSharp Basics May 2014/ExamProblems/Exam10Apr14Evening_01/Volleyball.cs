using System;

class Volleyball
{
    static void Main()
    {
        string leap = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        double totalPlays = h + (48 - h) * 3.0 / 4.0 + p * 2.0 / 3.0;

        if (leap == "leap")
        {
            totalPlays += totalPlays * 15.0 / 100.0; 
        }

        Console.WriteLine((int)totalPlays);
    }
}