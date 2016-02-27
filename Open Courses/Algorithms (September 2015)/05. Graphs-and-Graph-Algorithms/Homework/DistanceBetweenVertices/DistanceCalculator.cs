namespace DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DistanceCalculator
    {
        private static Dictionary<int, HashSet<int>> graph; 

        public static void Main()
        {
            graph = new Dictionary<int, HashSet<int>>();
            
            try
            {
                ReadGraph();
                CalculateDistances();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private static void CalculateDistances()
        {
            var line = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(line))
            {
                var pair = line
                    .Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var distance = BFS(pair[0], pair[1]);
                Console.WriteLine("{{{0}, {1}}} -> {2}", pair[0], pair[1], distance);

                line = Console.ReadLine();
            }
        }

        private static int BFS(int startNode, int needle)
        {
            if (!graph.ContainsKey(startNode) || !graph.ContainsKey(needle))
            {
                throw new ArgumentException("Both vertices should be presented in the graph");
            }

            var nodes = new Queue<int>();
            var visited = new Dictionary<int, int> {{startNode, 0}};

            nodes.Enqueue(startNode);

            while (nodes.Count != 0)
            {
                int currentNode = nodes.Dequeue();
                if (currentNode == needle)
                {
                    return visited[currentNode];
                }

                foreach (var childNode in graph[currentNode])
                {
                    if (!visited.ContainsKey(childNode))
                    {
                        nodes.Enqueue(childNode);
                        visited.Add(childNode, visited[currentNode] + 1);
                    }
                }
            }

            return -1;
        }

        private static void ReadGraph()
        {
            var line = Console.ReadLine();
            line = Console.ReadLine();

            while (line != null && line != "Distances to find:")
            {
                var inputLine = line
                    .Split(new[] {"->"}, StringSplitOptions.RemoveEmptyEntries);

                var vertice = int.Parse(inputLine[0]);
                graph[vertice] = new HashSet<int>();

                if (inputLine.Length > 1)
                {
                    var edges = inputLine[1]
                        .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();


                    foreach (int edge in edges)
                    {
                        graph[vertice].Add(edge);
                    }
                }

                line = Console.ReadLine();
            }
        }
    }
}
