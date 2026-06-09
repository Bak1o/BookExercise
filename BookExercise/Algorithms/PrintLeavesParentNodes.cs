using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class PrintLeavesParentNodes
    {
        public static void Run(BinaryTree<int> binaryTree)
        {
            if (!IsLeaf(binaryTree))
            {
                if ((IsLeaf(binaryTree.LeftChild) || binaryTree.LeftChild == null) && (IsLeaf(binaryTree.RightChild)
                    || binaryTree.RightChild == null))
                {
                    Console.WriteLine($" value of nodes with only leaves successor : {binaryTree.Value}");
                }
            }
            {
                Console.WriteLine($" {binaryTree.Value}");
            }
            if (binaryTree.LeftChild != null)
            {
                Run(binaryTree.LeftChild);
            }
            if (binaryTree.RightChild != null)
            {
                Run(binaryTree.RightChild);
            }
        }
        private static bool IsLeaf(BinaryTree<int> binaryTree)
        {
            if (binaryTree == null)
                return false;
            if (binaryTree.LeftChild == null && binaryTree.RightChild == null)
                return true;

            return false;
        }
    }
}
