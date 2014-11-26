using System;

//A marketing company wants to keep record of its employees. Each record would have the following characteristics:
// •	First name
// •	Last name
// •	Age (0...100)
// •	Gender (m or f)
// •	Personal ID number (e.g. 8306112507)
// •	Unique employee number (27560000…27569999)
//Declare the variables needed to keep the information for a single employee using appropriate primitive data types. Use descriptive names. Print the data at the console.

class EmployeeData
{
    static void Main()
    {
        string firstName = "Ivan";
        string lastName = "Ivanov";
        byte age = 100;
        char gender = 'm';
        string personalID = "8306112507";
        int employeeNumber = 27560035;
        Console.WriteLine("First name: \t\t {0}", firstName);
        Console.WriteLine("Last name: \t\t {0}", lastName);
        Console.WriteLine("Age: \t\t\t {0}", age);
        Console.WriteLine("Gender: \t\t {0}", gender);
        Console.WriteLine("Personal ID: \t\t {0}", personalID);
        Console.WriteLine("Unique employee number:  {0}", employeeNumber);
    }
}