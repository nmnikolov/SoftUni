//Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years.

using System;

class CalculateAge
{
    static void Main()
    {
        Console.WriteLine("Input your birthday:");
        DateTime birthday = DateTime.Parse(Console.ReadLine());
        DateTime today = DateTime.Today;
        int age = today.Year - birthday.Year;
        if (birthday > today.AddYears(-age))
        {
            age--;
        }
        Console.WriteLine("\nYour are {0} years old.", age);
        Console.WriteLine("You will be {0} years old after 10 years.", age + 10);
    }
}