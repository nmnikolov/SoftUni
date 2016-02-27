namespace GraphCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphCycles
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visitedNodes;
        private static HashSet<string> cycleNodes;
        private static bool isAcyclic;

        public static void Main()
        {
            graph = new Dictionary<string, List<string>>();
            visitedNodes = new HashSet<string>();
            cycleNodes = new HashSet<string>();
            isAcyclic = true;

            ReadGraph();

            foreach (var node in graph.Keys)
            {
                IsAcyclic(node, null);
            }

            Console.WriteLine("Acyclic: {0}", isAcyclic ? "Yes" : "No");
        }

        private static void IsAcyclic(string node, string lastNode)
        {
            if (cycleNodes.Contains(node))
            {
                isAcyclic = false;
                return;
            }

            if (!visitedNodes.Contains(node))
            {
                visitedNodes.Add(node);
                cycleNodes.Add(node);

                if (graph.ContainsKey(node))
                {
                    foreach (var childNode in graph[node])
                    {
                        if (childNode != lastNode)
                        {
                            IsAcyclic(childNode, node);
                        }
                    }
                }

                cycleNodes.Remove(node);
            }
        }

        private static void ReadGraph()
        {
            var line = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(line))
            {
                var vertices = line
                    .Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => n.Trim().ToUpper())
                    .ToArray();

                foreach (var vertex in vertices)
                {
                    if (!graph.ContainsKey(vertex))
                    {
                        graph[vertex] = new List<string>();
                    }
                }

                graph[vertices[0]].Add(vertices[1]);
                graph[vertices[1]].Add(vertices[0]);

                line = Console.ReadLine();
            }
        }
    }
}