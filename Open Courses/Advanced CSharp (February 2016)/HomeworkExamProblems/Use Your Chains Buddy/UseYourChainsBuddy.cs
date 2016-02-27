using System;
using System.Text.RegularExpressions;

namespace Use_Your_Chains_Buddy
{
   public class UseYourChainsBuddy
    {
        public static void Main()
        {
            string paragraphPattern = @"<p>(.*?)</p>";
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, paragraphPattern);
            string result = string.Empty;

            foreach (Match match in matches)
            {
                string matchedText = match.Groups[1].ToString();
                matchedText = Regex.Replace(matchedText, @"[^a-z\d]+", " ");               

                foreach (char chr in matchedText)
                {
                    if (char.IsLetter(chr) && chr <= 109)
                    {
                        result += (char)(chr + 13);
                    }
                    else if (char.IsLetter(chr) && chr >= 110)
                    {
                        result += (char)(chr - 13);
                    }
                    else
                    {
                        result += chr;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}