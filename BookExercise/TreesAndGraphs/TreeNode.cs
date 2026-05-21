using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.TreesAndGraphs
{
    internal class TreeNode<T>
    {
        private T _value;
        private bool _hasParent;
        private List<TreeNode<T>> _children;
        public TreeNode(T value)
        {
            if (value == null) 
                throw new ArgumentNullException("Cannot insers null value");
            _value = value;
            _children = new List<TreeNode<T>>();
        }
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public int ChildrenCount
        {
            get { return _children.Count; }
        }
        public void AddChild(TreeNode<T> child)
        {
            if (child == null) 
                throw new ArgumentNullException("Cannot insert null value");
            if (child._hasParent)
                throw new InvalidOperationException("the node already has a parent");
            child._hasParent = true;
            _children.Add(child);
                    
        }
        public TreeNode<T> GetChild(int index) => _children[index];




    }
}
