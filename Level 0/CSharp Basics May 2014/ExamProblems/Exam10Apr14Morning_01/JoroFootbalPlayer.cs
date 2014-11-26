using System;

class JoroFootbalPlayer
{
    static void Main()
    {
        string leap = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        double totalDays = h + (52 - h) * 2.0 / 3.0 + p * 0.5;

        if (leap == "t")
        {
            totalDays += 3;
        }

        Console.WriteLine((int)totalDays);
    }
}
