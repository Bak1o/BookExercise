using BookExercise.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class IsCyclicDFSUndirected
    {
        public static bool Run(Graph graph)
        {
            List<int>[] children = graph.ChildNodes;
            int[] parent = new int[graph.Size];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }
            bool[] isVisited = new bool[graph.Size];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < graph.Size; i++)
            {
                if (isVisited[i])
                    continue;
                stack.Push(i);
                isVisited[i] = true;
                while (stack.Count > 0)
                {
                    int currentNode = stack.Pop();
                    foreach (int node in children[currentNode])
                    {
                        if (!isVisited[node])
                        {
                            isVisited[node] = true;
                            parent[node] = currentNode;
                            stack.Push(node);
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
