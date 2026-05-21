using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.TreesAndGraphs
{
    internal class Tree<T>
    {
        private TreeNode<T> _root;
        public Tree(T value)
        {
            if (value == null) 
                throw new ArgumentNullException("Cannot insert null value");
            _root = new TreeNode<T>(value);
        }
        public Tree(T value, params Tree<T>[] children) : this(value) 
        {
            foreach (Tree<T> child in children)
            {
                _root.AddChild(child._root);
            }
        }
        public TreeNode<T> Root
        { 
            get 
            {
                return _root; 
            }
        }
        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (_root == null)
                return;
            Console.WriteLine(spaces + root.Value);
            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + " ");
            }
        }
        private (int leaves, int internalNodes) CountLeavesAndInternalNodes(TreeNode<T> node)
        {
            int leafCount = 0;
            int insideNodesCount = 0;
            if (node == null)
                return (leafCount, insideNodesCount);

            if (node.ChildrenCount > 0)
            {
                insideNodesCount++;
                for (int i = 0; i < node.ChildrenCount; i++)
                {
                    var childResult = CountLeavesAndInternalNodes(node.GetChild(i));
                    leafCount += childResult.Item1;
                    insideNodesCount += childResult.Item2;
                }
            }
            else
            {
                leafCount++;
            }
            return (leafCount, insideNodesCount);
        }
        public (int leaves, int internalNodes) NumberOfLeavesAndInternalNodes
        {
            get
            {
                return CountLeavesAndInternalNodes(_root);
            }
        }
        public void SubTreesWithNodeCount(int nodeCount)
        {
            SubTreesWithNodeCount(_root, nodeCount);

        }
        private List<TreeNode<T>> SubTreesWithNodeCount(TreeNode<T> node, int nodeCount)
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            if (node == null)
            {
                return nodes;
            }
            int size = 1;
            for (int i = 0;i < node.ChildrenCount; i++)
            {
                size += SubTreeSize(node.GetChild(i));
                
            }
            if (size == nodeCount)
            {
                nodes.Add(node);
            }

            for (int i = 0; i < node.ChildrenCount; i++)
            {
              var childNodes =  SubTreesWithNodeCount(node.GetChild(i), nodeCount);
                nodes.AddRange(childNodes);
            }
            return nodes;

            
        }
        private int SubTreeSize(TreeNode<T> node)
        {
            
            if(node == null)
            {
                return 0;
            }
            int size = 1;
            if (node.ChildrenCount == 0)
            {
                return size;
            }
            for (int i = 0; i < node.ChildrenCount; i++)
            {
                size+= SubTreeSize(node.GetChild(i));
            }
            return size;

        }
        public List<TreeNode<T>> NodesWithChildrenCount(int count)
        {
           List<TreeNode<T>> nodes = NodesWithChildrenCount(_root, count);
            return nodes;
        }
        private List<TreeNode<T>> NodesWithChildrenCount(TreeNode<T> node, int count)
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            if (node == null)
                return nodes;
           
            if (node.ChildrenCount == count)
            {
                nodes.Add(node);
            }
            
            for (int i = 0; i < node.ChildrenCount; i++)
            {
                 var childNodes = NodesWithChildrenCount(node.GetChild(i), count);
                nodes.AddRange(childNodes);
                
                
            }
            return nodes;
        }
        public void FindValueOccurences(T value)
        {
          int counter = FindValueOccurences(_root, value);
            Console.WriteLine(counter);
        }
        public void FindValueOccurrencesIterative(T value)
        {
           int counter = FindValueOccurrencesIterative(_root, value);
            Console.WriteLine(counter);
        }
        private int FindValueOccurences(TreeNode<T> root, T value)
        {
            int count = 0;
            if (root == null)
                return count;
            if (EqualityComparer<T>.Default.Equals(value, root.Value))
            {
                
                count++;
            }
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                var child = root.GetChild(i);
                count += FindValueOccurences(child, value);
            }
            return count;
        }
        private int FindValueOccurrencesIterative(TreeNode<T> root, T value)
        {
            int count = 0;
            TreeNode<T> child = null;
            if (root == null)
                return 0;
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode<T> currentRoot = stack.Pop();
                if (EqualityComparer<T>.Default.Equals(currentRoot.Value, value))
                {
                    count++;
                }
                for (int i = 0; i < currentRoot.ChildrenCount; i++)
                {
                    stack.Push(currentRoot.GetChild(i));

                }
            }
            return count;
        }
        public void TraverseDFS()
        {
            this.PrintDFS(_root, string.Empty);
        }
    }
}
