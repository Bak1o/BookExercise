using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms.SortingAlgorithms
{
    public class BubbleSort
    {
        public static void Run(int[] arr)
        {                                                              ///5, 3, 2, 7, 9, 1;
            int n = arr.Length;                                        // 3, 2, 5, 7, 1, 9;
            for (int i = 0; i < n - 1; i++)                            // 2, 3, 5, 1, 7, 9;
            {                                                          // 2, 3, 1, 5, 7, 9;
                for (int j = 0; j < n - i - 1; j++)                    // 2, 1, 3
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
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
