using BookExercise.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class IsCyclicBFSUndirected
    {
        public static bool Run(Graph graph)
        {

            List<int>[] childNodes = graph.ChildNodes;
            Queue<int> q = new Queue<int>();
            bool[] isVisited = new bool[graph.Size];
            int[] parent = new int[graph.Size];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }
            for (int i = 0; i < graph.Size; i++)
            {
                if (isVisited[i])
                    continue;
                q.Enqueue(i);
                isVisited[i] = true;
                while (q.Count > 0)
                {
                    int currentNode = q.Dequeue();
                    foreach (int node in childNodes[currentNode])
                    {
                        if (!isVisited[node])
                        {

                            isVisited[node] = true;
                            parent[node] = currentNode;
                            q.Enqueue(node);
                        }
                        else if (node != parent[currentNode])
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
