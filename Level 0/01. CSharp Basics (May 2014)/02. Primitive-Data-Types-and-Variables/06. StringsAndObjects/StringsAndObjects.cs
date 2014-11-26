using System;

//Declare two string variables and assign them with “Hello” and “World”. 
//Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval between). 
//Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).

class StringsAndObjects
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object concatenation = hello + " " + world;
        Console.WriteLine("Using concatenation: {0}", concatenation);
        string typeCasting = (string)concatenation;
        Console.WriteLine("Using type casting: {0}", typeCasting);
    }
}