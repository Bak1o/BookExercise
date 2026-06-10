using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures.DictionariesAndHashCodes
{
    internal class MyHashDictionary<K, V> : IMyDictionary<K, V>, IEnumerable<MyKeyValuePair<K, V>>
    {
        private const int DEFAULT_CAPACITY = 16;
        private const float DEFAULT_LOAD_FACTOR = 0.75f;
        private List<MyKeyValuePair<K, V>>[] _table;
        private float _loadFactor;
        private int _threshold;
        private int _size;
        private int _initialCapacity;

        public MyHashDictionary() : this(DEFAULT_CAPACITY, DEFAULT_LOAD_FACTOR) 
        {
            
        }
        public MyHashDictionary(int capacity, float loadFactor)
        {
            _initialCapacity = capacity;
            _table = new List<MyKeyValuePair<K, V>>[capacity];
            _loadFactor = loadFactor;
            _threshold = (int)(capacity * _loadFactor);
        }
        private List<MyKeyValuePair<K, V>> FindChain(K key, bool createIfMissing)
        { 
            int index = key.GetHashCode();
            index = index & 0x7FFFFFFF;
            index = index % _table.Length;
            if (_table[index] == null && createIfMissing)
            {
                _table[index] = new List<MyKeyValuePair<K, V>>();
            }
            return _table[index];
        }
        public V this[K key] { get => this.Get(key); set => this.Set(key,value); }

        public int Count
        {
            get 
            {
                return _size;
            }
        }

        public void Clear()
        {
            _table = new List<MyKeyValuePair<K, V>>[_initialCapacity];
            _size = 0;
        }

        public V Get(K key)
        {
            List<MyKeyValuePair<K, V>> chain = FindChain(key, false);
            if (chain != null)
            {
                foreach (MyKeyValuePair<K, V> pair in chain)
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
            }
            return default;

        }
        public int GetBucketIndex(K key)
        {
            int index = key.GetHashCode();
            index = index & 0x7FFFFFFF;
            index = index % _table.Length;
            return index;
        }
        private void Expand()
        {
            int newCapacity = _table.Length * 2;
            List<MyKeyValuePair<K, V>>[] oldTable = _table;
            _table = new List<MyKeyValuePair<K, V>>[newCapacity];
            _threshold = (int)(newCapacity * _loadFactor);
            foreach (List<MyKeyValuePair<K, V>> oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (MyKeyValuePair<K,V> pair in oldChain)
                    {
                        List<MyKeyValuePair<K,V>> chain = FindChain(pair.Key, true);
                        chain.Add(pair);
                    }
                }
            }
        }

       
        public bool Remove(K key)
        {
            List<MyKeyValuePair<K, V>> chain = FindChain(key, false);
            if (chain != null)
            {
                MyKeyValuePair<K, V> entry = new MyKeyValuePair<K, V>();
                for (int i = 0; i < chain.Count; i++)
                {
                    entry = chain[i];
                    if (entry.Key.Equals(key))
                    {
                        chain.RemoveAt(i);
                        _size--;
                        return true;
                    }
                }
                
            }
            return false;
        }

        public V Set(K key, V value)
        {
            if (_size >= _threshold)
            {
               this.Expand();
            }
            List<MyKeyValuePair<K, V>> chain = FindChain(key, true);

            for (int i = 0; i < chain.Count; i++)
            {
                MyKeyValuePair<K, V> entry = chain[i];
                if (entry.Key.Equals(key))
                {
                    MyKeyValuePair<K, V> newEntry = new MyKeyValuePair<K, V>(key, value);
                    chain[i] = newEntry;
                    return entry.Value;
                }
            }
            chain.Add(new MyKeyValuePair<K, V>(key, value));
            _size++;
            return default;
        }
        public void PrintBackets()
        {
            for (int i = 0; i < _table.Length; i++)
            {
                Console.Write($" bucket {i} : ");
                List<MyKeyValuePair<K,V>> chain = _table[i];
                if (chain == null || chain.Count == 0)
                {
                    Console.WriteLine("empty");
                    continue;
                }

                for (int j = 0; j < chain.Count; j++)
                {
                    MyKeyValuePair<K,V> pair = chain[j];
                    Console.Write($"[{pair.Key} -> {pair.Value}]");
                    if (j < chain.Count - 1)
                    {
                        Console.Write(" -> ");
                    }
                }
            }
            Console.WriteLine();
        }

        IEnumerator<MyKeyValuePair<K, V>> IEnumerable<MyKeyValuePair<K, V>>.GetEnumerator()
        {
            foreach (List<MyKeyValuePair<K, V>> chain in _table)
            {
                if (chain != null)
                {
                    foreach (MyKeyValuePair<K, V> entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<MyKeyValuePair<K, V>>)this).GetEnumerator();
        }
    }
}
