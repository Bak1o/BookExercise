using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms.SortingAlgorithms
{
    internal class QuickSort
    {
        public static void Run(int[] arr)
        {
            Sort(arr,0, arr.Length - 1);
        }
        public static void Sort(int[] arr, int startIndex, int endIndex)
        {                                              //{ 34, 5, 12, 56, 23, 35, 80, 2, 67 }
            if (startIndex >= endIndex)
                return;
            int pivotIndex = (startIndex + endIndex) / 2;
            int pivotElement = arr[pivotIndex];
            int i = startIndex;
            int j = endIndex;

            while (true)
            {
                while (arr[i] < pivotElement && i <= pivotIndex)
                {
                    i++;
                }
                while (arr[j] > pivotElement && j >= pivotIndex)
                {
                    j--;
                }
                if (i >= j)
                    break;
                if (i == pivotIndex)
                    pivotIndex = j;
                else if (j == pivotIndex)
                    pivotIndex = i;
                Swap(ref arr[i], ref arr[j]);
                i++;
                j--;
            }
            Sort(arr, startIndex, pivotIndex);
            Sort(arr, pivotIndex + 1, endIndex);



        }
        private static void Swap<T>(ref T item1, ref T item2)
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }
    }
}
