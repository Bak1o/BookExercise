using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class BFSTraverseForDirected
    {
        public static void Run(Graph graph)
        {
            List<int>[] childNodes = graph.ChildNodes;
            bool[] visited = new bool[graph.Size];
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < graph.Size; i++)
            {
                if (!visited[i])
                {
                    q.Enqueue(i);

                    visited[i] = true;
                    while (q.Count > 0)
                    {
                        int currentNode = q.Dequeue();
                        Console.Write($" {currentNode}");


                        foreach (int child in childNodes[currentNode])
                        {
                            if (!visited[child])
                            {
                                visited[child] = true;
                                q.Enqueue(child);


                            }
                        }

                    }
                }
            }
        }
    }
}
