using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures.TreesAndGraphs
{
    internal class BinaryTree<T>
    {
        public T Value { get; set; }
        public BinaryTree<T>? LeftChild { get; private set; }
        public BinaryTree<T>? RightChild { get; private set; }
        public BinaryTree(T value, BinaryTree<T>? leftChild, BinaryTree<T>? rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
        public BinaryTree(T value) : this(value, null, null)
        {

        }
        public BinaryTree(T value, BinaryTree<T>? leftChild) : this(value, leftChild, null)
        {

        }
       

        // Traverses in order Left-Root-Right
       
        public void PrintInOrder()
        {
            if (LeftChild != null)
            {
                LeftChild.PrintInOrder();
            }
            //this is root aka value in this case
            Console.WriteLine();
            Console.Write( Value  + " ");

            if (RightChild != null)
            {
                RightChild.PrintInOrder();
            }
        }
       

        //traverses in pre order root-left-right
        public void PrintPreOrder()
        {
            Console.Write(Value + "  ");
            if (LeftChild != null)
            {
                LeftChild.PrintPreOrder();
            }
            if (RightChild != null)
            { 
                RightChild.PrintPreOrder();
            }

        }

        //traverses in post order left-right-root
        public void PrintPostOrder()
        {
            if (LeftChild != null)
            {
                LeftChild.PrintPostOrder();
            }
            if (RightChild != null)
            {
                RightChild.PrintPostOrder();
            }
            Console.Write(Value + "  ");
        }
    }
}
            


            
    

