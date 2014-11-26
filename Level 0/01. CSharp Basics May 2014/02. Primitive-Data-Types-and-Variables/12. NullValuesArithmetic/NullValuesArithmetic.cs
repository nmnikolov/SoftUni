using System;

//Create a program that assigns null values to an integer and to a double variable. Try to print these variables at the console. 
//Try to add some number or the null literal to these variables and print the result.

class NullValuesArithmetic
{
    static void Main()
    {
        int? studentID = null;
        double? examResult = null;
        Console.WriteLine(studentID);
        Console.WriteLine(examResult);
        studentID += 1;
        examResult += 2;
        Console.WriteLine(studentID);
        Console.WriteLine(examResult);
        Console.WriteLine(studentID + "5");
        Console.WriteLine(examResult + "6");
    }
}