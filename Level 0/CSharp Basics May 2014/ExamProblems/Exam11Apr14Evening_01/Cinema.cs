using System;

class Cinema
{
    static void Main()
    {
        string projection = Console.ReadLine();
        decimal rows = decimal.Parse(Console.ReadLine());
        decimal columns = decimal.Parse(Console.ReadLine());
        decimal incomes = 0;

        if (projection == "Premiere")
        {
            incomes = 12M * rows * columns;
        }
        else if (projection == "Normal")
        {          
            incomes = 7.5M * rows * columns;
        }
        else
        {
            incomes = 5M * rows * columns;
        }

        Console.WriteLine("{0:F2} leva", incomes);
    }
}