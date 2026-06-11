using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms.SortingAlgorithms
{
    public class RadixSort
    {
       
        public static int[] Run(int[] arr)
        {
            long max = arr
                      .Select(x => Math.Abs((long)x))
                      .Max();
           
            return Sort(arr, 1, max);
        }
        public static int[] Sort(int[] arr, long place, long MaxMagnitude)
        {

            if (place > MaxMagnitude)
            {
                return arr;
            }
            int i;
            int sum = 0;
            int[] bucketArr = new int[19];

            int[] newArr = new int[arr.Length];

            int index = -1;
            for (i = 0; i < arr.Length; i++)
            {
                index = MapNumberIntoBucketIndex(arr[i], place);
                bucketArr[index] = bucketArr[index] + 1;
            }
            for (i = 1; i < bucketArr.Length; i++)
            {
                
                bucketArr[i] = bucketArr[i - 1] + bucketArr[i];
            }
            for (i = arr.Length - 1; i >= 0; i--)
            {

                index = MapNumberIntoBucketIndex(arr[i], place);
                newArr[bucketArr[index] - 1] = arr[i];
                bucketArr[index]--;
            }
            return Sort(newArr, place * 10, MaxMagnitude);



        }

        public static int MapNumberIntoBucketIndex(int number, long place)
        {
            int digit = (int)((number / place) % 10);
            return digit + 9;

        }
    }
}
