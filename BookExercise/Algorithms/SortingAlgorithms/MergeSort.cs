using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms.SortingAlgorithms
{
    internal static class MergeSort
    {
        public static void Run(int[] arr)
        {
            Divide(arr, 0, arr.Length - 1);
            foreach (int number in arr)
            {
                Console.Write($" {number}");
            }
        }
        private static void Divide(int[] arr, int startIndex, int endIndex)
        {

            if (startIndex >= endIndex)
                return;
            int mid = (startIndex + endIndex) / 2;
            Divide(arr, startIndex, mid);  //left
            Divide(arr, mid + 1, endIndex); //right
            Merge(arr, startIndex, mid, endIndex); //merge

        }
        private static void Merge(int[] array, int start, int midd, int end)
        {
            int lengthL = midd - start + 1;
            int lengthR = end - midd;
            int[] left = new int[lengthL];
            int[] right = new int[lengthR];
            int i, j;
            for (i = 0; i < lengthL; i++)
            {
                left[i] = array[start + i];
            }
            for (j = 0; j < lengthR; j++)
            {
                right[j] = array[midd + 1 + j];
            }
            i = 0;
            j = 0;
            int k = start;
            while (i < lengthL && j < lengthR)
            {
                if (left[i] <= right[j])
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }
            while (i < lengthL)
            {
                array[k] = left[i];
                i++;
                k++;
            }
            while (j < lengthR)
            {
                array[k] = right[j];
                j++;
                k++;
            }

        }
    }
}
