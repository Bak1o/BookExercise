using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms.SortingAlgorithms
{
    public class QuickSort
    {
        public static void Run(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            if (arr.Length == 0)
            {
                return;
            }
            Sort(arr,0, arr.Length - 1);
        }
        public static void Sort(int[] arr, int startIndex, int endIndex)
        {                                                               
                                                                        //{ 34, 5, 12, 56, 23, 35, 80, 2, 67 }
            if (startIndex >= endIndex)
                return;

            int pivotElement = arr[(startIndex + endIndex) / 2];

            int i = startIndex;
            int j = endIndex;

            while (i <= j)
            {
                while (i <= endIndex && arr[i] < pivotElement)
                {
                    i++;
                }

                while (j >= startIndex && arr[j] > pivotElement)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
            }

            if (startIndex < j)
            {
                Sort(arr, startIndex, j);
            }

            if (i < endIndex)
            {
                Sort(arr, i, endIndex);
            }



        }
        private static void Swap<T>(ref T item1, ref T item2)
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }
    }
}
