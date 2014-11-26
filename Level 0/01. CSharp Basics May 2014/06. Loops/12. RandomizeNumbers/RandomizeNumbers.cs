using System;
//using System.Linq;
using System.Collections.Generic;

//Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order. Examples:
// | n | randomized numbers 1…n |
// | 3 | 2 1 3                  |
// |10 | 3 4 8 2 6 7 9 1 10 5   |
//Note that the above output is just an example. Due to randomness, your program most probably will produce different results. You might need to use arrays.

class RandomizeNumbers
{
    static void Main()
    {
        Console.Write("Enter integer number n (1 <= n): ");
        int n;
        bool nParse = int.TryParse(Console.ReadLine(), out n);

        if (!nParse || n < 1)
        {
            Console.WriteLine("invalid input");
            return;
        }   

        List<int> list = new List<int>();
        string output = "";

        for (int i = 0; i < n; i++)
        {
            list.Add(i + 1);
        }

        for (int i = 0; i < n; i++)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, list.Count); //creating random index number
            int randomNumber = list[randomIndex]; 
            output += randomNumber + " "; //adding the random number to the output string
            list.Remove(randomNumber); //removing the random number from the list
        }

        Console.WriteLine(output.Trim());  
    }
}