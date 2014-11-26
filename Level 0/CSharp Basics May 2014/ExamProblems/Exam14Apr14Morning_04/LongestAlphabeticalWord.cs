using System;
using System.Collections.Generic;
using System.Linq;

class LongestAlphabeticalWord
{
    static void Main()
    {
        string word = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char [n , n];
        List<string> match = new List<string>();
        int count = 0;
        int max = 0;

        for (int row = 0; row < n; row++)
        {
            for (int coll = 0; coll < n; coll++)
            {
                matrix[row, coll] = word[count];
                count++;
                if (count == word.Length)
                {
                    count = 0;
                }
            }
        }

        for (int row = 0; row < n; row++)
        {
            for (int coll = 0; coll < n; coll++)
            {
               if (CheckUp(matrix, row, coll).Length >= max)
                {
                    match.Add(CheckUp(matrix, row, coll));
                    max = match[match.Count - 1].Length; ;
                }

                if (CheckDown(matrix, row, coll).Length >= max)
                {
                    match.Add(CheckDown(matrix, row, coll));
                    max = match[match.Count - 1].Length; ;
                }
                if (CheckLeft(matrix, row, coll).Length >= max)
                {
                    match.Add(CheckLeft(matrix, row, coll));
                    max = match[match.Count - 1].Length; ;
                }
                if (CheckRight(matrix, row, coll).Length >= max)
                {
                    match.Add(CheckRight(matrix, row, coll));
                    max = match[match.Count - 1].Length; ;
                }
            }
        }
        match = match.OrderBy(x => x.Length).ThenByDescending(x => x).ToList();
        Console.WriteLine(match.Last());
    }

    public static string CheckUp(char[,] matrix, int row, int coll)
    {
        string word = Convert.ToString(matrix[row, coll]);

        for (int i = row - 1; i >= 0; i--)
        {
            if (matrix[i, coll] > word[word.Length - 1])
            {
                word += matrix[i, coll];
            }
            else
            {
                break;
            }
        }
        return word;
    }

    public static string CheckDown(char[,] matrix, int row, int coll)
    {
        string word = Convert.ToString(matrix[row, coll]);

        for (int i = row + 1; i < matrix.GetLength(1); i++)
        {
            if (matrix[i, coll] > word[word.Length - 1])
            {
                word += matrix[i, coll];
            }
            else
            {
                break;
            }
        }
        return word;
    }

    public static string CheckLeft(char[,] matrix, int row, int coll)
    {
        string word = Convert.ToString(matrix[row, coll]);

        for (int i = coll - 1; i >= 0; i--)
        {
            if (matrix[row, i] > word[word.Length - 1])
            {
                word += matrix[row, i];
            }
            else
            {
                break;
            }
        }
        return word;
    }

    public static string CheckRight(char[,] matrix, int row, int coll)
    {
        string word = Convert.ToString(matrix[row, coll]);

        for (int i = coll + 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[row, i] > word[word.Length - 1])
            {
                word += matrix[row, i];
            }
            else
            {
                break;
            }
        }
        return word;
    }
}