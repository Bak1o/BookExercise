using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures.DictionariesAndHashCodes
{
    public interface IMyDictionary<K, V> : IEnumerable<MyKeyValuePair<K, V>>
    {
        V Get(K key);
        V Set(K key, V value);
        V this[K key] { get; set; }
        bool Remove(K key);
        int Count { get; }
        void Clear();
    }
}
