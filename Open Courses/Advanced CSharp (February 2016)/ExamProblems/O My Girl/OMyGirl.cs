using System;
using System.Security;
using System.Text.RegularExpressions;

namespace OMyGirl
{
    public class OMyGirl
    {
        private static string symbolPattern = @"[^a-zA-Z\d]";
        private static string uppercaseLetter = @"[A-Z]";
        private static string lowercaseLetter = @"[a-z]";
        private static string digit = @"[\d]";

        private static string input = "";

        public static void Main()
        {
            string pattern = "";

            string keyStr = Console.ReadLine();            

            pattern += Regex.Escape(keyStr[0].ToString());
            bool isActive = false;

            for (int i = 1; i < keyStr.Length - 1; i++)
            {
                string chr = keyStr[i].ToString();

                if (Regex.Match(chr, symbolPattern).Success)
                {
                    pattern += Regex.Escape(chr);
                    //isActive = false;
                    continue;
                }

                if (!isActive && Regex.Match(chr, uppercaseLetter).Success)
                {
                    pattern += uppercaseLetter + "*";
                    //isActive = true;
                    continue;
                }

                if (!isActive && Regex.Match(chr, lowercaseLetter).Success)
                {
                    pattern += lowercaseLetter + "*";
                    //isActive = true;
                    continue;
                }

                if (!isActive && Regex.Match(chr, digit).Success)
                {
                    pattern += "\\d*";
                    //isActive = true;
                    continue;
                }
            }

            pattern += Regex.Escape(keyStr[keyStr.Length - 1].ToString());
            pattern += "(.{2,6}?)" + pattern;

            ReadInput();            

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            string address = "";

            foreach (Match match in matches)
            {
                address += match.Groups[1].ToString();
            }

            Console.WriteLine(address);
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                input += line;

                line = Console.ReadLine();
            }
        }
    }
}