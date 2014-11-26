using System;

//Declare a Boolean variable called isFemale and assign an appropriate value corresponding to your gender. Print it on the console.

class BooleanVariable
{
    static void Main()
    {
        Console.WriteLine("Are you male or female? (answer with f/m or female/male)");
        string gender = Console.ReadLine();
        bool isfemale = (gender == "f" || gender == "female") ? true : false;
        bool ismale = (gender == "m" || gender == "male") ? true : false;
        if (isfemale)
        {
            Console.WriteLine("You are: female");
        }
        else if (ismale)
        {
            Console.WriteLine("You are: male");
        }
        else
        {
            Console.WriteLine("Invalid input!");  
        }
    }
}