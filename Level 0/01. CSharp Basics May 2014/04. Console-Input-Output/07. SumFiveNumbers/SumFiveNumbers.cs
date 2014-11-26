using System;

//Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum. Examples:
// | numbers   | sum | numbers	      | sum | numbers           |   sum |
// | 1 2 3 4 5 |  15 | 10 10 10 10 10 |	 50 | 1.5 3.14 8.2 -1 0 | 11.84 |

class SumFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Input 5 numbers in a row separated by a space:");
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        double sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            double element = double.Parse(numbers[i]);
            sum += element;
        }
        Console.WriteLine(sum);
    }
}