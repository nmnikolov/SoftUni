using System;

//Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix holding 
//the numbers from 1 to n*n in the form of square spiral like in the examples below. Examples:
// | n | matrix |   | n | matrix |   | n | matrix     |   
// | 2 | 1 2    |   | 3 | 1 2 3  |   | 4 | 1  2  3  4 |
// |   | 4 3    |   |   | 8 9 4  |   |   | 12 13 14 5 |
//                      | 7 6 5  |   |   | 11 16 15 6 |
//                                   |   | 10 9  8  7 |

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter integer number n (1 <= n <= 20): ");
        int n;
        bool nParse = int.TryParse(Console.ReadLine(), out n);

        if (!nParse || n < 1 || n > 20)
        {
            Console.WriteLine("invalid input");
            return;
        }

        int[,] array = new int[n, n];
        int direction = 1;  // 1 = down - left   -1 = up - right
        int row = 0;
        int col = 0;
        int count = n - 1;
        int number = 1;

        for (int i = 0; i < n; i++)
        {
            array[row, col++] = number++;
        }
        col--;

        for (int j = 0; j < n - 1; j++)
        {
            if (direction == 1)
            {
                //fill values down
                for (int i = 0; i < count; i++)
                {
                    array[++row, col] = number++;
                }
                //fill values left
                for (int i = 0; i < count; i++)
                {
                    array[row, --col] = number++;
                }
                count--;
            }
            else
            {
                //fill values up
                for (int i = 0; i < count; i++)
                {
                    array[--row, col] = number++;
                }
                //fill values right
                for (int i = 0; i < count; i++)
                {
                    array[row, ++col] = number++;
                }
                count--;
            }
            direction *= -1;
        }

        //Print matrix
        Console.WriteLine("Matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (n > 9)
                {
                    Console.Write("{0,-4}", array[i, j]);
                }
                else if (n > 3)
                {
                    Console.Write("{0,-3}", array[i, j]);
                }
                else
                {
                    Console.Write("{0,-2}", array[i, j]);
                }
            }
            Console.WriteLine();
        }
    }
}