using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class BinaryTreeIsBalanced
    {
        public static bool IsBalanced<T>(BinaryTree<T>? tr)
        {
            if (tr == null)
                return true;
            int leftHeight = Height(tr.LeftChild);
            int rightHeight = Height(tr.RightChild);


            if (Math.Abs(leftHeight - rightHeight) > 1)
                return false;

            return IsBalanced(tr.LeftChild) && IsBalanced(tr.RightChild);

        }
        private static int Height<T>(BinaryTree<T>? tr)
        {
            if (tr == null)
                return 0;


            int leftHeight = Height(tr.LeftChild);
            int rightHeight = Height(tr.RightChild);
            int max = Math.Max(leftHeight, rightHeight) + 1;
            return max;





        }
    }
}
