using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures
{
    internal class CustomDeque<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        private int _count;
        public CustomDeque(int capacity = 5)
        {
            _items = new T[capacity];
            _head = 0;
            _tail = 0;
            _count = 0;

        }
        public void AddTop(T item)
        {
            if (IsFull())
            {
                Resize();
            }
            _head = (_head - 1 + _items.Length) % _items.Length;
            _items[_head] = item;
            _count++;
        }
        public void AddBottom(T item)
        {
            if (IsFull())
            {
                Resize();
            }
            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _count++;
        }
        private void Resize()
        {
            int newCapacity = _items.Length * 2;
            T[] newArray = new T[newCapacity];

            // Un-wrap elements into the new array
            for (int i = 0; i < _count; i++)
            {
                // (head + i) % length finds the correct logical element
                newArray[i] = _items[(_head + i) % _items.Length];
            }

            _items = newArray;
            _head = 0;
            _tail = _count;// Next item will be added at the end of existing items

        }
       
        public T RemoveTop()
        {
            if ( IsEmpty())
            {
                throw new InvalidOperationException("Deque is empty");
            }
            var item = _items[_head];
            _head = (_head + 1) % _items.Length;
            _count--;
            return item;

        }
        public T RemoveBottom()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Deque is Empty");
            }
            _tail = (_tail - 1 + _items.Length) % _items.Length;
            var item = _items[_tail];
            _count--;
            return item;
        }
        private bool IsFull() => _count == _items.Length;
        private bool IsEmpty() => _count == 0;
    }
}
