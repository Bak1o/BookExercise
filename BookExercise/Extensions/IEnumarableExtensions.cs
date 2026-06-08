using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Extensions
{
    internal static class IEnumarableExtensions
    {
        public static string ToString<T>(
            this IEnumerable<T> enumeration)
        {
            StringBuilder result = new StringBuilder();
            result.Append("[");
            foreach (var item in enumeration)
            {
                result.Append(item.ToString());
                result.Append(", ");
            }
            if (result.Length > 1)
                result.Remove(result.Length - 2, 2);
            result.Append(']');
            return result.ToString();
        }
        public static T Sum<T>(this IEnumerable<T> enumeration) where T : struct 
        {
            if (enumeration == null)
                throw new ArgumentNullException(nameof(enumeration));

            dynamic sum = default(T);
            foreach (var item in enumeration)
            {
                sum += item;
            }
            return sum;
        }
        public static T Max<T>(this IEnumerable<T> enumeration) where T : struct, IComparable<T>
        {
            if (enumeration == null)
                throw new ArgumentNullException(nameof(enumeration));
           using var enumerator = enumeration.GetEnumerator();
            if (!enumerator.MoveNext())
                throw new InvalidOperationException("Sequence contains no elements");

            T max = enumerator.Current;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.CompareTo(max) > 0)
                {
                    max = enumerator.Current;
                }
            }
            return max;
        }
        public static T Min<T>(this IEnumerable<T> enumeration) where T : struct, IComparable<T>
        {
            if (enumeration == null)
                throw new ArgumentNullException(nameof(enumeration));
            using var enumerator = enumeration.GetEnumerator();
            if (!enumerator.MoveNext())
                throw new InvalidOperationException("Sequence contains no elements");

            T min = enumerator.Current;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.CompareTo(min) < 0)
                {
                    min = enumerator.Current;
                }
            }
            return min;
        }
        public static double Average<T>(this IEnumerable<T> enumeration) where T : struct
        {
            if (enumeration == null)
                throw new ArgumentNullException(nameof(enumeration));
            int count = enumeration.Count();
            dynamic sum = enumeration.Sum();
            return (double)(sum / count);
        }
    }
}
