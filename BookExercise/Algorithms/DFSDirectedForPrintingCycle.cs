using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class DFSDirectedForPrintingCycle
    {
        public static void TraverseDFSDirectedForPrintingCycle(Graph graph)
        {
            bool[] visited = new bool[graph.Size];
            bool[] inStack = new bool[graph.Size];
            int[] parent = new int[graph.Size];
            for (int i = 0; i < graph.Size; i++)
            {
                parent[i] = -1;
            }
            for (int i = 0; i < graph.Size; i++)
            {
                if (visited[i])
                    continue;
                TraverseDFSDirectedForPrintingCycle(i, graph, visited, inStack, parent);
            }
        }


        private static void TraverseDFSDirectedForPrintingCycle(int v, Graph graph, bool[] visited, bool[] inStack, int[] parent)
        {
            if (!visited[v])
            {
                visited[v] = true;
                inStack[v] = true;
                foreach (int child in graph.GetSuccesors(v))
                {

                    if (!visited[child])
                    {
                        parent[child] = v;
                        TraverseDFSDirectedForPrintingCycle(child, graph, visited, inStack, parent);

                    }
                    else if (inStack[child])
                    {

                        PrintCycleDirectedGraph(v, child, parent);
                    }
                }
                inStack[v] = false;
            }
        }
        private static void PrintCycleDirectedGraph(int currentNode, int startCycleNode, int[] parent)
        {
            // i need to reverse parent for correct order. aka stack it reverses order
            int node = currentNode;
            Stack<int> stack = new Stack<int>();
            while (node != -1)
            {
                if (node == startCycleNode)
                {
                    stack.Push(node);
                    break;
                }
                stack.Push(node);
                node = parent[node];


            }
            Console.Write("Printing Cycle :");
            while (stack.Count > 0)
            {
                Console.Write($" {stack.Pop()}");
            }
            Console.Write($" {startCycleNode}");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
