using System;

class ProgrammerDNA
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char startLetter = char.Parse(Console.ReadLine().ToUpper());
        char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        int index = Array.IndexOf(letters, startLetter);
        int rowLettersCount = 1;

        for (int row = 0; row < n; row++)
        {
            rowLettersCount = row % 7 == 0 ? rowLettersCount = 1 : rowLettersCount;
 
            string dots = new string('.', (7 - rowLettersCount)/2 );
            Console.WriteLine(dots + LettersOnARow(rowLettersCount, index, letters) + dots);
            index += rowLettersCount;
            index = index > 6 ? index -= 7 : index;
            rowLettersCount = row % 7 < 3 ? rowLettersCount += 2 : rowLettersCount -= 2;             
        }        
    }

    public static string LettersOnARow(int numberOfLetters, int index, char[] letters)
    {
        string rowLetters = "";
        for (int i = 0; i < numberOfLetters; i++)
        {
            rowLetters += letters[index];
            index++;
            index = index == 7 ? index = 0 : index;
        }
        return rowLetters;       
    }
}