using BookExercise.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class DjikstraAllShortPath
    {
        public static void Run(WeightedGraph graph, int startNode)
        {
            int[] distance = new int[graph.Size];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
            }
            bool[] visited = new bool[graph.Size];
            int[] parent = new int[graph.Size];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            distance[startNode] = 0;
            pq.Enqueue(startNode, distance[startNode]);
            while (pq.Count > 0)
            {
                int currentNode = pq.Dequeue();

                if (!visited[currentNode])
                {
                    visited[currentNode] = true;

                    foreach (Edge edge in graph.GetSuccesors(currentNode))
                    {
                        if (!visited[edge.To])
                        {
                            int newDistance = distance[currentNode] + edge.Weight;
                            if (newDistance < distance[edge.To])
                            {
                                distance[edge.To] = newDistance;
                                parent[edge.To] = currentNode;
                                pq.Enqueue(edge.To, newDistance);
                            }
                        }
                    }
                }
            }

            PrintAllPathDjikstra(parent, startNode, distance);

        }
        private static void PrintAllPathDjikstra(int[] parent, int startNode, int[] distance)
        {


            for (int i = 0; i < distance.Length; i++)
            {
                if (distance[i] == int.MaxValue)
                {
                    Console.WriteLine($"{startNode} --> {i} path not found");
                    continue;
                }

                Stack<int> stack = new Stack<int>();

                int currentNode = i;

                while (currentNode != -1)
                {
                    stack.Push(currentNode);
                    currentNode = parent[currentNode];
                }

                Console.Write($"{startNode} --> {i} path: ");

                while (stack.Count > 0)
                {
                    Console.Write($"{stack.Pop()} ");
                }

                Console.WriteLine($" distance = {distance[i]}");
            }
        }
    }
}
