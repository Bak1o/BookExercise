using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.DictionariesAndHashCodes
{
    internal class MValueDictionary<K, V> : IEnumerable<KeyValuePair<K, List<V>>>
    {
        private Dictionary<K, List<V>> _multiValueDictionary;
        private int _count;
        public MValueDictionary()
        {
            _multiValueDictionary = new Dictionary<K, List<V>>();
            _count = 0;
        }
        public List<V> this[K key]
        {
            get
            {
                if (!_multiValueDictionary.TryGetValue(key, out List<V> list))
                {
                    list = new List<V>();
                    
                }
                return list;
            }
            set
            {
                if(_multiValueDictionary.TryGetValue(key, out List<V> list))
                {
                    _count = _count - list.Count;
                }
                _count += value.Count;
                _multiValueDictionary[key] = value;
            }
        }

        public ICollection<K> Keys => _multiValueDictionary.Keys;

        public ICollection<V> Values => throw new NotImplementedException();

        public int KeyCount => _multiValueDictionary.Count;
        public int ValueCount => _count;

        public bool IsReadOnly => false;

        public void Add(K key, V value)
        {
            if (!_multiValueDictionary.TryGetValue(key, out List<V> list))
            {
                list = new List<V>();
                this[key] = list;
            }
            list.Add(value);
            _count++;
        }
        public void Add(K key,List<V> values)
        {
            if (!_multiValueDictionary.TryGetValue(key, out List<V> list))
            {
                list = new List<V>();
                this[key] = list;
            }
            foreach (var value in values)
            {
               list.Add(value);
            }
            _count += values.Count;
        }
        public void Add(KeyValuePair<K, V> item)
        {
            if (!_multiValueDictionary.TryGetValue(item.Key, out List<V> list))
            {
                list = new List<V>();
                this[item.Key] = list;
            }
            list.Add(item.Value);
            
            _count++;
        }

        public void Clear()
        {
            _multiValueDictionary?.Clear();
            _count = 0;
        }

        public bool Contains(KeyValuePair<K,V> item)
        {
           if(_multiValueDictionary.TryGetValue(item.Key, out List<V> list))
            {
                return list.Contains(item.Value);
            }
           return false;
        }

        public bool ContainsKey(K key)
        {
            return _multiValueDictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<K, List<V>>[] array, int arrayIndex)
        {
            if (array == null) 
                throw new ArgumentNullException("array");
            if (arrayIndex < 0 || arrayIndex > array.Length)
                throw new ArgumentException($"{arrayIndex}");
            if (array.Length < arrayIndex + _multiValueDictionary.Count )
                throw new ArgumentException($"{array}");
            int index = arrayIndex;
            
            foreach(KeyValuePair<K,List<V>> item in _multiValueDictionary)
            {
                array[index] = item;
                index++;
               
            }
           
            
        }

        public IEnumerator<KeyValuePair<K, List<V>>> GetEnumerator()
        {
            return _multiValueDictionary.GetEnumerator();
        }

        public bool Remove(K key)
        {
            if(_multiValueDictionary.TryGetValue(key, out List<V> list))
            {
                _count = _count - list.Count;
            }
            return _multiValueDictionary.Remove(key);
        }

        public bool Remove(KeyValuePair<K, V> item)
        {
            if (_multiValueDictionary.TryGetValue(item.Key, out List<V> list))
            {
                if (list.Count == 1)
                {
                    if (EqualityComparer<V>.Default.Equals(list[0], item.Value))
                    { 
                        _count--;
                        return _multiValueDictionary.Remove(item.Key);
                    }
                    return false;
                }
               if (list.Remove(item.Value))
                {
                    _count--;
                    return true;
                }

            }
            return false;
        }

        public bool TryGetValue(K key, [MaybeNullWhen(false)] out List<V> value)
        {
            if (_multiValueDictionary.TryGetValue(key, out List<V> list))
            {
                value = list;
                return true;
            }
            value = default; 
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
