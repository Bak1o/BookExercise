using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.DictionariesAndHashCodes
{
    public struct MyKeyValuePair<TKey,TValue>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; private set; }
        public MyKeyValuePair(TKey key,TValue value) : this()
        {
            Key = key;
            Value = value;
        }
        public override string ToString()
        {
           StringBuilder builder = new StringBuilder();
            builder.Append('[');
            if(Key != null)
                builder.Append(Key.ToString());
            builder.Append(", ");
            if(Value != null)
                builder.Append(Value.ToString());
            builder.Append(']');
            return builder.ToString();
        }

    }
}
