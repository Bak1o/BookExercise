using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms.SortingAlgorithms
{
    internal static class MergeSortTuple
    {
        public static void Run((string name, int price)[] array)
        {
            Divide(array,0,array.Length - 1);
        }
       
        private static void Divide((string name, int price)[] arr, int start, int end)
        {
            if (start >= end)
                return;
            int midd = (start + end) / 2;
            Divide(arr, start, midd);
            Divide(arr, midd + 1, end);
            Merge(arr, start, midd, end);
        }
        private static void Merge((string name, int price)[] arr, int start, int mid, int end)
        {
            int leftLength = mid - start + 1;
            int rightLegth = end - mid;
            int i;
            int j;
            int k;
            k = start;
            (string name, int price)[] leftArr = new (string, int)[leftLength];
            (string name, int price)[] rightArr = new (string, int)[rightLegth];
            for (i = 0; i < leftLength; i++)
            {
                leftArr[i] = arr[k];
                k++;
            }

            for (j = 0; j < rightLegth; j++)
            {
                rightArr[j] = arr[k];
                k++;
            }
            i = 0;
            j = 0;                                       //  4, 35, 56/ 6, 12, 90
            k = start;
            while (i < leftLength && j < rightLegth)
            {
                var leftElement = leftArr[i];
                var rightElement = rightArr[j];
                if (leftElement.price <= rightElement.price)
                {
                    arr[k] = leftElement;
                    i++;
                }
                else
                {
                    arr[k] = rightElement;
                    j++;
                }
                k++;
            }
            while (i < leftLength)
            {
                arr[k] = leftArr[i];
                i++;
                k++;
            }
            while (j < rightLegth)
            {
                arr[k] = rightArr[j];
                j++;
                k++;
            }



        }
    }
}
