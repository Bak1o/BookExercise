using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures
{
    internal class CustomArrayList<T>
    {
        private T[] _arr;
        private int _count;
        public int Count
        {
            get { return _count; }
        }

        private const int INITIAL_CAPACITY = 4;
        public CustomArrayList(int capacity = INITIAL_CAPACITY)
        {
            _arr = new T[capacity];
            _count = 0;
        }
        public void Add(T item)
        {
            GrowIfArrIsFull();
            _arr[_count] = item;
            _count++;
        }

        public void Insert(int index, T item)
        {
            if (index > _count || index < 0)
            {
                throw new IndexOutOfRangeException($" invalid index : {index} ");
            }
            GrowIfArrIsFull();
            Array.Copy(_arr, index, _arr, index + 1, _count - index);//_arr, index, _arr, index +1,_count - index
            _arr[index] = item;
            _count++;

        }
        private void GrowIfArrIsFull()
        {
            if (_count + 1 > _arr.Length)
            {
                T[] extendedArr = new T[_arr.Length * 2];
                Array.Copy(_arr, extendedArr, _count);
                _arr = extendedArr;


            }
        }
        public void Clear()
        {
            _arr = new T[INITIAL_CAPACITY];
            _count = 0;
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                if (Equals(_arr[i], item))
                {
                    return i;
                }
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
                {
                    throw new ArgumentOutOfRangeException($" invalid index : {index}");
                }
                return _arr[index]; 
            }
            set
            {
                if (index >= _count || index < 0)
                {
                    throw new ArgumentOutOfRangeException($" invalid index : {index}");
                }
                _arr[index] = value;

            }

        }

        public T RemoveAt(int index)
        {
            if (index >= _count || index < 0)
            {
                throw new ArgumentOutOfRangeException($" Invalid index : {index} ");
            }
            T item = _arr[index];
            Array.Copy(_arr, index + 1, _arr, index, _count - index - 1);
            _arr[_count - 1] = default;
            _count--;
            return item;
        }

        public int Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
            }
            return index;
        }



    }
}
