using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class GenerateSubSets
    {
        public static void GenerateSubsets(int[] arr, int index, List<int> current)
        {

            if (index == arr.Length)
            {
                if (current.Sum() == arr.Length)
                {
                    Print(current);
                }
                return;
            }

            current.Add(arr[index]);
            GenerateSubsets(arr, index + 1, current);
            current.RemoveAt(current.Count - 1);
            GenerateSubsets(arr, index + 1, current);

        }
        private static void Print(List<int> subset)
        {
            Console.Write(" { ");
            foreach (int i in subset)
            {
                Console.Write($" {i} ");
            }
            Console.WriteLine(" } ");
        }
    }
}

