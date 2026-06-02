using BookExercise.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class HasHamiltonianCycle
    {
        public static bool Run(Graph graph)
        {
            int count = 0;
            int n = graph.Size;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (!(graph.HasEdge(i, j)))
                    {
                        if (!(graph.GetSuccesors(i).Count + graph.GetSuccesors(j).Count >= n))
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            if (count == 0)
                return true;
            bool[] visited = new bool[graph.Size];
            List<int> path = new List<int>();
            bool result = DFSForHamiltonianiCycle(graph, 0, visited, path);
            if (result)
            {
                Console.Write("Hamiltonian cycle: ");
                foreach (int node in path)
                    Console.Write(node + " ");

                Console.WriteLine(path[0]);
            }
            return result;

        }
        private static bool DFSForHamiltonianiCycle(Graph graph, int start, bool[] visited, List<int> path)
        {
            int currentNode = start;
            visited[currentNode] = true;
            path.Add(currentNode);
            if (path.Count == graph.Size)
            {
                if (graph.HasEdge(currentNode, path[0]))
                    return true;
                visited[currentNode] = false;
                path.RemoveAt(path.Count - 1);
                return false;
            }
            foreach (int child in graph.GetSuccesors(currentNode))
            {
                if (!visited[child])
                {
                    if (DFSForHamiltonianiCycle(graph, child, visited, path))
                        return true;

                }
            }
            visited[currentNode] = false;
            path.RemoveAt(path.Count - 1);
            return false;


        }
    }
}
