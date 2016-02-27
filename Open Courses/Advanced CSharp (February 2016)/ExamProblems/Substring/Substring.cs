using System;

namespace Substring
{
    public class Substring
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine());            
            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'p')
                {
                    hasMatch = true;
                    int endIndex = i + jump;
                    endIndex = Math.Min(endIndex, text.Length - 1);
                    
                    string matchedString = text.Substring(i, endIndex - i + 1);
                    Console.WriteLine(matchedString);
                    i += jump;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
