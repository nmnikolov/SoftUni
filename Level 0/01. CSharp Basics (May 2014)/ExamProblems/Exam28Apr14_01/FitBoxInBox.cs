using System;

class FitBoxInBox
{
    static void Main()
    {
        int w1 = int.Parse(Console.ReadLine().Trim());
        int h1 = int.Parse(Console.ReadLine().Trim());
        int d1 = int.Parse(Console.ReadLine().Trim());
        int w2 = int.Parse(Console.ReadLine().Trim());
        int h2 = int.Parse(Console.ReadLine().Trim());
        int d2 = int.Parse(Console.ReadLine().Trim());

        int min1 = Math.Min(Math.Min(w1, h1), d1);
        int min2 = Math.Min(Math.Min(w2, h2), d2);

        if (min1 < min2)
        {
            Check(w1, h1, d1, w2, h2, d2);
            Check(w1, h1, d1, w2, d2, h2);
            Check(w1, h1, d1, h2, w2, d2);
            Check(w1, h1, d1, h2, d2, w2);
            Check(w1, h1, d1, d2, w2, h2);
            Check(w1, h1, d1, d2, h2, w2);          
        }
        else
        {
            Check(w2, h2, d2, w1, h1, d1);
            Check(w2, h2, d2, w1, d1, h1);
            Check(w2, h2, d2, h1, w1, d1);
            Check(w2, h2, d2, h1, d1, w1);
            Check(w2, h2, d2, d1, w1, h1);
            Check(w2, h2, d2, d1, h1, w1);    
        }
    }

    public static void Check(int w1, int h1, int d1, int w2, int h2, int d2)
    {
        if (w2 > w1 && h2 > h1 && d2 > d1)
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", w1, h1, d1, w2, h2, d2);
        }
    }
}