using System;

class Tables
{
    static void Main()
    {
        long legs = 0;
        for (int i = 1; i < 5; i++)
        {
            legs += long.Parse(Console.ReadLine()) * i;
        }
        int tops = int.Parse(Console.ReadLine());
        int tablesRequired = int.Parse(Console.ReadLine());

        long tablesReady = Math.Min(legs / 4, tops);

        if (tablesReady == tablesRequired)
        {
            Console.WriteLine("Just enough tables made: {0}", tablesReady);
        }
        else if (tablesReady < tablesRequired)
        {
            Console.WriteLine("less: {0}", tablesReady - tablesRequired);
            Console.WriteLine("tops needed: {0}, legs needed: {1}", Math.Max(0, tablesRequired - tops), Math.Max(0, tablesRequired * 4 - legs));
        }
        else
        {
            Console.WriteLine("more: {0}", tablesReady - tablesRequired);
            Console.WriteLine("tops left: {0}, legs left: {1}", Math.Max(0, tops - tablesRequired), Math.Max(0, legs - tablesRequired * 4));
        }
    }
}