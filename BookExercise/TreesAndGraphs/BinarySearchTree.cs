using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.TreesAndGraphs
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        internal class BinaryTreeNode<T> :
            IComparable<BinaryTreeNode<T>> where T : IComparable<T>
        {
            internal T _value;
            internal BinaryTreeNode<T> _parent;
            internal BinaryTreeNode<T> _leftChild;
            internal BinaryTreeNode<T> _rightChild;
            public BinaryTreeNode(T value)
            {
                if (value == null)
                    throw new ArgumentNullException("Cannot insert null value");
                _value = value;
                _parent = null;
                _leftChild = null;
                _rightChild = null;

            }
            public override string ToString()
            {
                return _value.ToString();
            }
            public override int GetHashCode()
            {
                return _value.GetHashCode();
            }
            public override bool Equals(object? obj)
            {
                if (!(obj is BinaryTreeNode<T>))
                    return false;
                BinaryTreeNode<T> other = obj as BinaryTreeNode<T>;
                return this.CompareTo(other) == 0;
            }
            public int CompareTo(BinaryTreeNode<T> other)
            {
                return _value.CompareTo(other._value);
            }
        }
        private BinaryTreeNode<T> _root;
        public BinarySearchTree()
        {
            _root = null;
        }
        public void Insert(T value)
        {
            _root = Insert(value, null, _root);
        }
        private BinaryTreeNode<T> Insert(
            T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                currentNode = new BinaryTreeNode<T>(value);
                currentNode._parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(currentNode._value);
                if (compareTo < 0)
                {
                    currentNode._leftChild = Insert(value, currentNode, currentNode._leftChild);
                }
                else if (compareTo > 0)
                {
                    currentNode._rightChild = Insert(value, currentNode, currentNode._rightChild);
                }
            }
            return currentNode;
        }
        private BinaryTreeNode<T> Find(T value)
        {
            BinaryTreeNode<T> node = _root;
            while (node != null)
            {
                int compareTo = value.CompareTo(node._value);
                if (compareTo < 0)
                {
                    node = node._leftChild;
                }
                else if (compareTo > 0)
                {
                    node = node._rightChild;
                }
                else
                {
                    break;
                }
            }
            return node;
        }
        public bool Contains(T value)
        {
            bool found = this.Find(value) != null;
            return found;
        }
        public void Remove(T value)
        {
            BinaryTreeNode<T> nodeToDelete = Find(value);
            if (nodeToDelete != null)
            {
                Remove(nodeToDelete);
            }
        }
        private void Remove(BinaryTreeNode<T> node)
        {
            if (node._leftChild != null && node._rightChild != null)
            {
                BinaryTreeNode<T> replacement = node._rightChild;
                while (replacement._leftChild != null)
                {
                    replacement = replacement._leftChild;
                }
                node._value = replacement._value;
                node = replacement;
            }
            BinaryTreeNode<T> theChild = node._leftChild != null ? node._leftChild : node._rightChild;
            if (theChild != null)
            {
                theChild._parent = node._parent;
                if (node._parent == null)
                {
                    _root = theChild;
                }
                else
                {
                    if (node._parent._leftChild == node)
                    {
                        node._parent._leftChild = theChild;
                    }
                    else
                    {
                        node._parent._rightChild = theChild;
                    }
                }
            }
            else
            {
                if (node._parent == null)
                {
                    _root = null;
                }
                else
                {
                    if (node._parent._leftChild == node)
                    {
                        node._parent._leftChild = null;

                    }
                    else
                    {
                        node._parent._rightChild = null;
                    }

                }
            }
        }
        public void PrintTreeDFS()
        {
            PrintTreeDFS(_root);
            Console.WriteLine();
        }
        private void PrintTreeDFS(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PrintTreeDFS(node._leftChild);
                Console.Write(node._value + " ");
                PrintTreeDFS(node._rightChild);
            }
        }
    }
}
