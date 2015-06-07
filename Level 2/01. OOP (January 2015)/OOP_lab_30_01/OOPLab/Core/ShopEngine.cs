
namespace MultimediaShop.Core
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Interfaces;

    public class ShopEngine
    {
        private ISet<string> uniqueIds = new HashSet<string>(); 
        
        private IDictionary<IItem, int> shopSupplies = new Dictionary<IItem, int>();

        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();

                String[] inputCommand = command.Split(' ');

                switch (inputCommand[0])
                {
                    case "supply": 
                        this.ParseCommand(inputCommand);
                        break;

                }
            }
        }

        private void ParseCommand(string[] command)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] pairs = command[3].Split('&');

            foreach (var pair in pairs)
            {
                string[] keyValuePair = pair.Split('=');
                keyValuePairs[keyValuePair[0]] = keyValuePair[1];
            }

           this.SupplyShop(command[1], int.Parse(command[2]), keyValuePairs);
        }

        private void SupplyShop(string type, int quantity, Dictionary<string, string> parameters)
        {
            
        }
    }
}