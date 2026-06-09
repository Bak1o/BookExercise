using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class TraverseDFS
    {
        public static void Run(Graph graph)
        {

            bool[] visited = new bool[graph.Size];
            for (int i = 0; i < graph.Size; i++)
            {
                if (visited[i])
                    continue;
                DFSTraverse(i, graph, visited);
            }
        }
        private static void DFSTraverse(int v, Graph graph, bool[] visited)
        {

            if (!visited[v])
            {
                Console.Write(v + " ");
                visited[v] = true;
                foreach (int child in graph.GetSuccesors(v))
                {
                    if (!visited[child])
                    {
                        DFSTraverse(child, graph, visited);
                    }
                }
            }
        }
    }
}
