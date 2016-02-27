using System;
using System.Text.RegularExpressions;

namespace PINValidation
{
    public class PINValidation
    {
        public static int[] multipliers = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        public static PINData pinData;

        public static void Main()
        {
            Regex regex = new Regex(@"\s*([A-Z]{1}[a-z]+\s+[A-Z]{1}[a-z]+)\s(male|female)\s+([0-9]{10})$");

            string inputData = "";

            for (int i = 0; i < 3; i++)
            {
                inputData += Console.ReadLine() + "\n";
            }

            var match = regex.Match(inputData);

            if (!match.Success)
            {
                PrintError();
                return;
            }

            if (!IsValid(match))
            {   
                PrintError();
                return;
            }

            PrintData(match);
        }

        private static void PrintData(Match data)
        {
            string name = data.Groups[1].ToString();
            string gender = data.Groups[2].ToString();
            string pin = data.Groups[3].ToString();

            Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", name, gender, pin);
        }

        public static bool IsValid(Match match)
        {
            pinData = ParsePin(match.Groups[3].ToString());
            string gender = match.Groups[2].ToString();

            if ((pinData.Month > 12 && pinData.Month < 21) || (pinData.Month > 32 && pinData.Month < 41) || pinData.Month > 52)
            {
                return false;
            }

            if ((pinData.Gender % 2 == 0 && gender == "female") || (pinData.Gender % 2 != 0 && gender == "male"))
            {
                return false;
            }

            int sum = 0;

            for (int i = 0; i < multipliers.Length; i++)
            {
                sum += int.Parse(pinData.PIN[i].ToString()) * multipliers[i];
            }

            if (((sum % 11) % 10) != pinData.CheckSum)
            {
                return false;
            }

            return true;
        }

        public static void PrintError()
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
        }

        public static PINData ParsePin(string pinStr)
        {
            int month = int.Parse(pinStr.Substring(2, 2));
            int gender = int.Parse(pinStr[8].ToString());
            int cheecksum = int.Parse(pinStr[9].ToString());

            PINData pinData = new PINData
            {
                PIN = pinStr,
                Month = month,
                Gender = gender,
                CheckSum = cheecksum
            };

            return pinData;
        }
    }

    public class PINData
    {
        public string PIN { get; set; }
        public int Month { get; set; }
        public int Gender { get; set; }
        public int CheckSum { get; set; }
    }
}