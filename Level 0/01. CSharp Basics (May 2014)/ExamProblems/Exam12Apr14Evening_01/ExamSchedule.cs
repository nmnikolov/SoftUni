using System;
using System.Globalization;
using System.Threading;

class ExamSchedule
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
        int hour = int.Parse(Console.ReadLine());
        int minute = int.Parse(Console.ReadLine());
        string partOfDay = Console.ReadLine();
        int hourAdd = int.Parse(Console.ReadLine());
        int minuteAdd = int.Parse(Console.ReadLine());

        DateTime startTime = new DateTime(2014, 07, 15, hour, minute, 0);
        DateTime endTime = startTime.AddHours(hourAdd).AddMinutes(minuteAdd);

        if (partOfDay == "PM")
        {
            endTime = endTime.AddHours(12);
        }

        Console.WriteLine(endTime.ToString("hh:mm:tt"));
    }
}