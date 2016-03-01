using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedCsharp
{
    public class CollectResources
    {
        private static HashSet<string> validResources = new HashSet<string>
        {
            "stone", "gold", "wood", "food"
        };

        private static List<int> resourcesWithValues = new List<int>();
        private static List<string> resourcesNames = new List<string>();
        private static int max = int.MinValue;

        public static void Main()
        {
            string[] resourcesRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);  

            ReadResourcesData(resourcesRow);
            ProcessMoves();  

            Console.WriteLine(max);
        }

        private static void ProcessMoves()
        {
            int moves = int.Parse(Console.ReadLine());

            for (int i = 0; i < moves; i++)
            {
                int currentSum = 0;
                bool[] visited = new bool[resourcesNames.Count];                

                int[] rowData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int start = rowData[0];
                int step = rowData[1];

                while (!visited[start])
                {
                    if (validResources.Contains(resourcesNames[start]))
                    {
                        visited[start] = true;
                        currentSum += resourcesWithValues[start];
                    }

                    start = (start + step) % resourcesNames.Count;
                }

                max = Math.Max(max, currentSum);
            }
        }

        private static void ReadResourcesData(string[] resourcesRow)
        {
            foreach (string strRow in resourcesRow)
            {
                var resourceData = strRow.Split('_');
                string resource = resourceData[0];
                int quantity = 1;

                if (resourceData.Length > 1)
                {
                    quantity = int.Parse(resourceData[1]);
                }

                resourcesWithValues.Add(quantity);
                resourcesNames.Add(resource);
            }
        }
    }
}
