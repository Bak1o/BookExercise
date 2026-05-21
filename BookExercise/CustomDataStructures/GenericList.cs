using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures
{
    internal class GenericList<T>
    {
        private T[]? _elements;
        public T[]? Elements
        {
            get { return _elements; }
        }

        public GenericList()
        {
            _elements = new T[1];
        }
        public GenericList(params T[] items)
        {
            _elements = new T[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                _elements[i] = items[i];
            }
        }
       
        public void Add(T item)
        {
            int index = -1;
           for (int i = 0; i < _elements.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_elements[i],default))
                {
                    index = i; break;
                }
            }
           if (index < 0)
            {
                Resize(_elements.Length + 1);
                _elements[_elements.Length - 1] = item;
            }
            else
            {
                _elements[index] = item;
            }
           
        }

        public void Remove(int index)
        {
            if (index >= _elements.Length)
                throw new ArgumentOutOfRangeException("index");

            T[] array = new T[_elements.Length - 1];
            int j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i == index)
                {
                    j++;
                }
                array[i] = _elements[j];
                j++;

            }

            _elements = array;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Printing list of elements");
            if (_elements != null)
            {
                foreach (var element in _elements)
                {
                    Console.Write($" {element} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(" List is empty ");
            }
        }
        public void PrintInfo(int index)
        {
            if (index >= _elements.Length || index < 0)
                throw new ArgumentOutOfRangeException("index");
            Console.WriteLine("Printing element of list ");
            Console.WriteLine(_elements[index]);
        }
        public T AccessElement(int index)
        {
            if (index >= _elements.Length || index < 0)
                throw new ArgumentOutOfRangeException("index");
            return _elements[index];

        }

        private void Resize(int newSize)
        {
            T[] arr = new T[newSize];
            for (int i = 0;i < _elements.Length;i++)
            {
                arr[i] = _elements[i];
            }
            _elements = arr;
        }
        public bool Contains(T item)
        {
            foreach (var element in _elements)
            {
                if (EqualityComparer<T>.Default.Equals(element, item))
                {
                    return true;
                }
            }
            return false;
        }
        public void Clear()
        {
            _elements = null;
        }
        public override string ToString()
        {
            if (_elements == null)
            {
                return "List is empty";
            }
            return string.Join(" ", _elements.Select(e => e?.ToString()));
        }

        
    }
}
