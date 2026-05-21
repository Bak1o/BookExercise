using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures
{
    internal class AnotherDynamicStack<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;
        }
        private Node _top;

        public void Push(T item)
        {
            _top = new Node { Data = item, Next = _top };
        }

        public T Pop()
        {
            if (_top == null) throw new InvalidOperationException("Stack empty");
            T data = _top.Data;
            _top = _top.Next;
            return data;
        }
    }
}
