using System;

//Write a program that, depending on the user’s choice, inputs an int, double or string variable. If the variable is int or double, the program increases it by one. 
//If the variable is a string, the program appends "*" at the end. Print the result at the console. Use switch statement. 
//Example:
// | program	            | user  |    | program	              | user  |
// |------------------------|-------|    |------------------------|-------|
// | Please choose a type:  |       |    | Please choose a type:  |       |
// | 1 --> int              |       |    | 1 --> int              |       |
// | 2 --> double           | 3     |    | 2 --> double           | 2     |
// | 3 --> string	        |       |    | 3 --> string	          |       |
// |------------------------|-------|    |------------------------|-------|
// | Please enter a string: | hello |    | Please enter a double: | 1.5   |
// |------------------------|-------|    |------------------------|-------|
// | hello*	                |       |    | 2.5   	              |       |
// |------------------------|-------|    |------------------------|-------|

class IntDoubleAndString
{
    static void Main()
    {
        byte choice = 0;
        try
        {
            Console.WriteLine("Please choose a type:");
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");
            choice = byte.Parse(Console.ReadLine());

            switch (choice)
	        {
                case 1:
                    Console.Write("Please enter an int: ");
                    int inputInt = int.Parse(Console.ReadLine());
                    Console.WriteLine(inputInt + 1);
                    break;
                case 2:
                    Console.Write("Please enter a double: ");
                    double inputDouble = double.Parse(Console.ReadLine());
                    Console.WriteLine(inputDouble + 1.0);
                    break;
                case 3:
                    Console.Write("Please enter a string: ");
                    string inputString = Console.ReadLine();
                    Console.WriteLine(inputString + "*");
                    break;
		        default:
                    Console.WriteLine("Invalid choice");
                    break;
	        }
        }

        catch (Exception)
        {
            if (choice > 0 && choice < 4)
            {
                Console.WriteLine("Invalid int/double input!");
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }        
    }
}