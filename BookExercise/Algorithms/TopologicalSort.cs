using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class TopologicalSort
    {
        public static void ArrangeTasks(Graph graph)
        {
            bool[] visited = new bool[graph.Size];
            bool[] inStack = new bool[graph.Size];
            Stack<int> result = new Stack<int>();
            for (int i = 0; i < graph.Size; i++)
            {
                if (!visited[i])
                {
                    if (!TopologicalDFS(graph, i, visited, inStack, result))
                    {
                        Console.WriteLine("Can't arrange tasks. There is a cycle.");
                        return;
                    }
                }
            }
            Console.Write("Order:");
            while (result.Count > 0)
            {
                Console.Write(" " + result.Pop());
            }
        }
        public static bool TopologicalDFS(Graph graph, int node, bool[] visited, bool[] inStack, Stack<int> result)
        {
            visited[node] = true;
            inStack[node] = true;
            foreach (int child in graph.GetSuccesors(node))
            {
                if (!visited[child])
                {
                    if (!TopologicalDFS(graph, child, visited, inStack, result))
                        return false;
                }
                else if (inStack[child])
                {
                    return false;
                }
            }
            inStack[node] = false;
            result.Push(node);
            return true;
        }
    }
}
