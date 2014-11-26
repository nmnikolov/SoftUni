using System;

class MagicDates
{
    static void Main()
    {
        DateTime startDate = new DateTime(int.Parse(Console.ReadLine()), 01, 01);
        DateTime endDate = new DateTime(int.Parse(Console.ReadLine()), 12, 31);
        int weight = int.Parse(Console.ReadLine());
        int count = 0;

        while (startDate <= endDate)
        {
            int dateWeight = 0;
            string date = startDate.ToString("ddMMyyyy");

            for (int i = 0; i < date.Length - 1; i++)
            {
                for (int j = i + 1; j < date.Length; j++)
                {
                    dateWeight += (int)Char.GetNumericValue(date[i]) * (int)Char.GetNumericValue(date[j]);
                }
            }

            if (dateWeight == weight)
            {
                Console.WriteLine(startDate.ToString("dd-MM-yyyy"));
                count++;
            }

            startDate = startDate.AddDays(1);          
        }

        if (count == 0)
        {
            Console.WriteLine("No");
        }
    }
}