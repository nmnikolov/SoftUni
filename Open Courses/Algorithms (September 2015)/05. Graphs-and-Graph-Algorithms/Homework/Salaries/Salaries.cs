namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Salaries
    {
        private static List<List<int>> graph;
        private static long[] salaries; 
        private static bool[] hasParents;
        private static bool[] visited;
        private static long totalSalaries;


        public static void Main()
        {
            ReadInput();

            for (int i = 0; i < hasParents.Length; i++)
            {
                if (!hasParents[i])
                {
                    DFS(i);
                }
            }

            Console.WriteLine(totalSalaries);
        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;
            salaries[node] = 0;

            if (graph[node].Any())
            {
                foreach (var childNode in graph[node])
                {
                    DFS(childNode);
                    salaries[node] += salaries[childNode];
                }
            }
            else
            {
                salaries[node] = 1;
            }

            totalSalaries += salaries[node];
        }

        private static void ReadInput()
        {
            var numberOfEmployees = int.Parse(Console.ReadLine());
            graph = new List<List<int>>(numberOfEmployees);
            salaries = new long[numberOfEmployees];
            hasParents = new bool[numberOfEmployees];
            visited = new bool[numberOfEmployees];
            totalSalaries = 0;

            for (int i = 0; i < numberOfEmployees; i++)
            {
                graph.Add(new List<int>());
                var employee = Console.ReadLine();

                for (int c = 0; c < employee.Length; c++)
                {
                    if (employee[c] == 'Y')
                    {
                        graph[i].Add(c);
                        hasParents[c] = true;
                    }
                }
            }
        }
    }
}