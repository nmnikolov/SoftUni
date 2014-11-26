using System;

class WorkHours
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        double hours = d * 12.0 - (12.0 * d) * (10.0 / 100.0);
        hours *= p / 100.0;

        if (hours >= h)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }

        Console.WriteLine(Math.Floor(hours - h));
    }
}