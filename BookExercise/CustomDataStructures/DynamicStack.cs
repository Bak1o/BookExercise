using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures
{
    internal class DynamicStack<T>
    {
        private class Node
        {
            public T Element;
            public Node? Previous;

            public Node(T element, Node? previous)
            {
                Element = element;
                Previous = previous;
            }
        }
        private Node? _top;
        private int _count;
        public int Count
            
        { 
            get
            { 
                return _count; 
            }
        }
        public DynamicStack()
        {
            _top = null;
            _count = 0;
        }
        public void Push(T item)
        {
            
            
                _top = new Node(item,_top);
                _count++;
            
        }
        public T Pop()
        {
            if (_top == null)
            {
                throw new InvalidOperationException(" Stack is empty ");
            }
            T item = _top.Element;
            _top = _top.Previous;
            _count--;
            return item;
        }
        public void Clear()
        {
            _top = null;
            _count = 0;
        }
    }
}
