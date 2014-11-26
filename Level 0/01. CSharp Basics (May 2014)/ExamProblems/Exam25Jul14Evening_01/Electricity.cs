using System;

class Electricity
{
    static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        DateTime time = DateTime.Parse(Console.ReadLine());
        double lampConsuming = 100.53;
        double computerConsuming = 125.90;
        double wats = 0;

        if (time.Hour >= 14 && time.Hour <= 18)
        {
            wats = floors * flats * 2 * lampConsuming + floors * flats * 2 * computerConsuming;
        }
        else if (time.Hour >= 19 && time.Hour <= 23)
        {
            wats = floors * flats * 7 * lampConsuming + floors * flats * 6 * computerConsuming;
        }

        else if (time.Hour >= 0 && time.Hour <= 8)
        {
            wats = floors * flats * lampConsuming + floors * flats * 8 * computerConsuming;

        }
        Console.WriteLine("{0} Watts", (int)wats);
    }
}