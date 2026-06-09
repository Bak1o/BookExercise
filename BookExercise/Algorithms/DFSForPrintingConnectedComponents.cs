using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class DFSForPrintingConnectedComponents
    {
        public static void Run(Graph graph)
        {
            bool[] visited = new bool[graph.Size];


            for (int i = 0; i < graph.Size; i++)
            {
                if (visited[i])
                    continue;
                Console.Write("Connected compononents : ");
                DFSForPrintConnectedComponents(i, graph, visited);
                Console.WriteLine();
            }
        }
        private static void DFSForPrintConnectedComponents(int v, Graph graph, bool[] visited)
        {
            if (!visited[v])
            {
                visited[v] = true;
                Console.Write($" {v}");
                foreach (int child in graph.GetSuccesors(v))
                {

                    DFSForPrintConnectedComponents(child, graph, visited);
                }
            }
        }
    }
}
