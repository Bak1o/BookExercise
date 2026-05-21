using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures
{
    public class DynamicList<T>
    {
        private class ListNode
        {
            public T Element { get; set; }
            public ListNode? NextNode { get; set; }
            public ListNode(T element) 
            {
                Element = element;
                NextNode = null;
            }
            public ListNode(T element,ListNode prevNode)
            {
                Element = element;
                prevNode.NextNode = this;
            }
        }
        private ListNode? _head;
        private ListNode? _tail;
        private int _count;
        public DynamicList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        public void Add(T item)
        {
            if (_head == null)
            {
                _head = new ListNode(item);
                _tail = _head;
            }
            else
            {
                ListNode newNode = new ListNode(item, _tail);
                _tail = newNode;
            }
            _count++;
        }
        public T RemoveAt(int index)
        {
            if (index >= _count || index < 0)
                throw new ArgumentOutOfRangeException($" Invalid index : {index} ");
            int currentIndex = 0;
            ListNode currentNode = _head;
            ListNode prevNode = null;
            while (currentIndex < index)
            {
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }
            RemoveListNode(currentNode, prevNode);
            return currentNode.Element;
        }
        private void RemoveListNode(ListNode node, ListNode prevNode)
        {
            _count--;
            if (_count == 0)
            {
                _head = null;
                _tail = null;
            }
            else if (prevNode == null)
            {
                _head = node.NextNode;

            }
            else
            {
                prevNode.NextNode = node.NextNode;

            }
            if (ReferenceEquals(_tail, node))
            {
                _tail = prevNode;
            }
        }
        public int Remove(T item)
        {
            int currentIndex = 0;
            ListNode currentNode = _head;
            ListNode prevNode = null;
            while (currentNode != null)
            {
                if (Equals(currentNode.Element, item))
                {
                    break;
                }
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++; 
            }
            if (currentNode != null)
            {
                RemoveListNode(currentNode, prevNode);
                return currentIndex;    
            }
            return -1;
        }
        public int IndexOf(T item)
        {
            int index = 0;
            ListNode currentNode = _head;
            while (currentNode != null)
            {
                if (Equals(currentNode.Element,item))
                {
                    return index;
                }
                currentNode = currentNode.NextNode;
                index++;
            }
            return -1;
        }
        public bool Contains(T item)
        {
            int index = IndexOf(item);
            bool found = index != -1;
            return found;
        }
        public T this[int index]
        {
            get
            {
                if (index >= _count || index < 0)
                    throw new ArgumentOutOfRangeException($" Invalid index : {index} ");
                ListNode currentNode = _head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }
                return currentNode.Element;
            }
            set
            {
                if (index >= _count || index < 0)
                    throw new ArgumentOutOfRangeException($" Invalid index : {index} ");
                ListNode currentNode = _head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }
                currentNode.Element = value;

            }
        }

        public int Count
        {
            get { return _count; }
        }
        
    }
}
