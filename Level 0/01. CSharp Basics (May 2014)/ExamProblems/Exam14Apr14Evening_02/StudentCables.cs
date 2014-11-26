using System;

class StudentCables
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int lenght = 0;
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            string measure = Console.ReadLine();

            switch (measure)
            {
                case "meters":
                    number *= 100; break;
            }

            if (number >= 20)
            {
                lenght += number;
                count++;
            }            
        }
        lenght -= 3 * (count - 1);
        Console.WriteLine(lenght / 504);
        Console.WriteLine(lenght % 504);      
    }
}