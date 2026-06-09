using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class HasEulerianCycle
    {
        public static bool Run(Graph graph)
        {
            int countIsolatedNodes = 0;
            int countEvenDegreeNodes = 0;
            bool[] isolated = new bool[graph.Size];
            for (int i = 0; i < graph.Size; i++)
            {
                if (graph.GetSuccesors(i).Count() == 0)
                {
                    isolated[i] = true;
                    countIsolatedNodes++;
                }
                else if (graph.GetSuccesors(i).Count() % 2 == 0)
                {
                    countEvenDegreeNodes++;
                }
            }
            if (countIsolatedNodes + countEvenDegreeNodes != graph.Size)
                return false;
            return GraphIsConnected(graph, isolated);


        }

        private static bool GraphIsConnected(Graph graph, bool[] isolated)
        {
            bool[] visited = new bool[graph.Size];
            for (int i = 0; i < graph.Size; i++)
            {
                if (graph.GetSuccesors(i).Count() > 0)
                {
                    TraverseDFS(i, graph, visited);
                    break;
                }
            }
            for (int i = 0; i < graph.Size; i++)
            {
                if (!(visited[i] == (!isolated[i])))
                    return false;
            }
            return true;

        }
        private static void TraverseDFS(int v, Graph graph, bool[] visited)
        {

            if (!visited[v])
            {
                Console.Write(v + " ");
                visited[v] = true;
                foreach (int child in graph.GetSuccesors(v))
                {
                    if (!visited[child])
                    {
                        TraverseDFS(child, graph, visited);
                    }
                }
            }
        }
    }
}
