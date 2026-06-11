using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms.SortingAlgorithms
{
    public static class CountingSort
    {
        public static int[] Run(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            if (arr.Length == 0)
            {
                return Array.Empty<int>();
            }
            int min = arr.Min();
            int max = arr.Max();
            int[] countArr = new int[max - min + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                countArr[arr[i] - min]++;
            }
            int sum = 0;
            for (int i = 0; i < countArr.Length; i++)
            {
                if (countArr[i] == 0)
                    continue;
                sum = sum + countArr[i];
                countArr[i] = sum;
            }
            int[] newArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[countArr[arr[i] - min] - 1] = arr[i];
                countArr[arr[i] - min]--;
            }
            return newArr;

        }
    }
}
