using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class BFSShortPath
    {
        public static void Run(Graph graph, int startNode, int EndNode)
        {
            if (startNode < 0 || startNode >= graph.Size ||
                         EndNode < 0 || EndNode >= graph.Size)
                return;

            List<int>[] childNodes = graph.ChildNodes;
            if (childNodes[startNode] != null)
            {
                bool[] visited = new bool[graph.Size];
                int[] parent = new int[graph.Size];
                for (int i = 0; i < parent.Length; i++)
                {
                    parent[i] = -1;
                }
                Queue<int> q = new Queue<int>();
                q.Enqueue(startNode);
                visited[startNode] = true;
                while (q.Count > 0)
                {
                    int currentNode = q.Dequeue();

                    if (currentNode == EndNode)
                    {
                        PathReconstruction(parent, currentNode);
                        break;
                    }
                    foreach (int child in childNodes[currentNode])
                    {
                        if (!visited[child])
                        {
                            q.Enqueue(child);
                            parent[child] = currentNode;
                            visited[child] = true;
                        }
                    }

                }
                if (!visited[EndNode])
                {
                    Console.WriteLine("Path was not found");
                }

            }
        }
        private static void PathReconstruction(int[] parent, int endNode)
        {
            List<int> path = new List<int>();
            int node = endNode;

            while (node != -1)
            {
                path.Add(node);
                node = parent[node];
            }
            path.Reverse();
            Console.Write("path :");
            foreach (int child in path)
            {
                Console.Write($" {child} ");
            }
        }
    }
}
