using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms.SortingAlgorithms
{
    public class InsertionSort
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
            int currentIndex;
            for (int i = 1; i < arr.Length; i++)
            {
                currentIndex = i;
                int value = arr[i];
                while (currentIndex > 0 && value < arr[currentIndex - 1])
                {
                    arr[currentIndex] = arr[currentIndex - 1];
                    currentIndex--;
                }
                arr[currentIndex] = value;
            }
        }
    }
}
