using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class PrintSumOfNodesEveryLevel
    {
        public static void Run(BinaryTree<int> binaryTree)
        {

            if (binaryTree == null)
                return;

            Queue<BinaryTree<int>> q = new Queue<BinaryTree<int>>();
            int level = 1;
            q.Enqueue(binaryTree);
            while (q.Count > 0)
            {
                int sum = 0;
                int levelSize = q.Count;


                for (int i = 0; i < levelSize; i++)
                {
                    BinaryTree<int> currentTree = q.Dequeue();
                    sum = sum + currentTree.Value;
                    if (currentTree.LeftChild != null)
                    {
                        q.Enqueue(currentTree.LeftChild);
                    }
                    if (currentTree.RightChild != null)
                    {
                        q.Enqueue(currentTree.RightChild);
                    }
                }
                Console.WriteLine($" level : {level}, sum of node values : {sum}");
                level++;
            }


        }
    }
}
