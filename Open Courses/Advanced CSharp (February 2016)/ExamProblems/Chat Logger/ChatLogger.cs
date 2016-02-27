using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

namespace Chat_Logger
{
    public class ChatLogger
    {
        private static DateTime currentDate;
        private static Regex regex = new Regex(@"(.+)\/(.*)");
        private static SortedList<DateTime, Message> messages = new SortedList<DateTime, Message>();
        
        public static void Main()
        {
            currentDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            ReadInput();
            PrintMessage();
        }

        private static void PrintMessage()
        {
            var selectedmessage = messages.Where(m => m.Key <= currentDate).ToList();

            foreach (Message message in messages.Values)
            {
                Console.WriteLine("<div>{0}</div>", SecurityElement.Escape(message.Text));
            };

            Console.WriteLine("<p>Last active: <time>{0}</time></p>", GetLastActive(selectedmessage.Last().Value));

        }

        private static string GetLastActive(Message lastMessage)
        {
            int diff = (int)(currentDate - lastMessage.Date).TotalMinutes;

            if (currentDate.Date == lastMessage.Date.Date)
            {
                if (diff == 0)
                {
                    return "a few moments ago";
                }

                if (diff < 60)
                {
                    return diff + " minute(s) ago";
                }

                if (diff < 1440)
                {
                    return diff / 60 + " hour(s) ago";
                }
            }
            
            

            if (currentDate.Date == lastMessage.Date.AddDays(1).Date)
            {
                return "yesterday";
            }

            return lastMessage.Date.ToString("dd-MM-yyyy");
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                ParseMessage(line);
                line = Console.ReadLine();
            }
        }

        private static void ParseMessage(string messageStr)
        {
            Match match = regex.Match(messageStr);

            if (match.Success)
            {
                string dateStr = match.Groups[2].ToString().Trim();
                DateTime messageDate = DateTime.ParseExact(dateStr, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                Message message = new Message
                {
                    Text = match.Groups[1].ToString().Trim(),
                    Date = messageDate
                };

                messages.Add(messageDate, message);
            }
        }
    }

    public class Message
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}