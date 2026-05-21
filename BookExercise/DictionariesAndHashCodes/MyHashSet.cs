using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.DictionariesAndHashCodes
{
    public class MyHashSet<T> : IEnumerable<T>
    {
        private MyHashDictionary<T, bool> _items;
        public MyHashSet()
        {
            _items = new MyHashDictionary<T, bool>();
        }
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }
        public bool Add(T item)
        {
            int oldCount = _items.Count;
            _items[item] = true;
            return _items.Count > oldCount;
        }
        public bool Remove(T item)
        {
            return _items.Remove(item);
        }
        public bool Contains(T item)
        {
            return _items.Get(item);
        }
        public void Clear()
        { 
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (MyKeyValuePair<T,bool> item in _items)
            {
                yield return item.Key;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
