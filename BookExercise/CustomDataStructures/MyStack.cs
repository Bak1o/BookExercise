using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures
{
    internal class MyStack<T>
    {
        private T[] _items;
        private int _top = -1;
        public MyStack(int capacity = 4)
        {
            _items = new T[capacity];
        }

        public void Push(T item)
        {
            if (_top == _items.Length - 1)
            {
                Resize(_items);
            }
            _top++;
            _items[_top] = item;
        }
        public T Pop()
        {
            if (_top == -1)
            {
                throw new InvalidOperationException("Stack overflow");
            }
            return _items[_top--];
            
        }
        public T Peek()
        {
                return _items[_top];
        }
        private void Resize(T[] elements) 
        {
            T[] array = new T[elements.Length * 2];
            Array.Copy(elements, array, elements.Length);
            _items = array;
        }
    }
}
