using System;

//Write a program that enters two dates in format dd.MM.yyyy and returns the number of days between them. 
//Examples:
// | First date  | Days between |
// | Second date |              |
// |-------------|------------- |
// | 17.03.2014  |              |
// | 30.04.2014	 | 44           |
// |-------------|------------- |
// | 17.03.2014  |              |
// | 17.03.2014	 | 0            |
// |-------------|------------- |
// | 14.06.1980  |              |
// | 5.03.2014	 | 12317        |
// |-------------|------------- |
// | 5.03.2014   |              |
// | 3.03.2014	 | -2           |

class DifferenceBetweenDates
{
    static void Main()
    {
        Console.Write("Enter start date in format dd.MM.yyyy: ");
        DateTime startDate;
        bool startDateParse = DateTime.TryParse(Console.ReadLine(), out startDate);
        Console.Write("Enter end date in format dd.MM.yyyy: ");
        DateTime endDate;
        bool endDateParse = DateTime.TryParse(Console.ReadLine(), out endDate);

        if (startDateParse && endDateParse)
        {
            Console.WriteLine(daysDifference(startDate, endDate));            
        }
        else
        {
            Console.WriteLine("invalid input");
        }
    }

    static double daysDifference (DateTime startDate, DateTime endDate)
    {
        double days = (endDate - startDate).TotalDays;
        return days;
    }
}