using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms.SortingAlgorithms
{
    internal class RadixSort
    {
        public static int[] Run(int[] arr)
        {
            int max = arr.Max();
            int num = max - 1;
            int baseNum = 10;
            int count = 0;
            while (num != max)
            {
                num = max % baseNum;
                count++;
                baseNum = baseNum * 10;

            }
            baseNum = 1;
            int maxBaseNum;
            for (int i = 0; i < count; i++)
            {
                baseNum = baseNum * 10;
            }
            maxBaseNum = baseNum;
            baseNum = 10;
            return Sort(arr, baseNum, maxBaseNum);
        }
        public static int[] Sort(int[] arr, int baseNum, int maxBaseNum)
        {

            if (baseNum > maxBaseNum)
            {
                return arr;
            }
            int i;
            int sum = 0;
            int[] bucketArr = new int[10];

            int[] newArr = new int[arr.Length];

            int index = -1;
            for (i = 0; i < arr.Length; i++)
            {
                index = MapNumberIntoBucketIndex(arr[i], baseNum);
                bucketArr[index] = bucketArr[index] + 1;
            }
            for (i = 0; i < bucketArr.Length; i++)
            {
                if (bucketArr[i] == 0)                                         //{ 170, 45, 75, 90, 802, 24, 2, 66 }
                    continue;
                sum = sum + bucketArr[i];
                bucketArr[i] = sum;
            }
            for (i = arr.Length - 1; i >= 0; i--)
            {

                index = MapNumberIntoBucketIndex(arr[i], baseNum);
                newArr[bucketArr[index] - 1] = arr[i];
                bucketArr[index]--;
            }
            return Sort(newArr, baseNum * 10, maxBaseNum);



        }

        public static int MapNumberIntoBucketIndex(int number, int baseNum)
        {
            int currentBase = 10;
            int baseTen = 10;
            int index = -1;
            while (currentBase <= baseNum)
            {
                index = number % baseTen;
                number = number / baseTen;
                currentBase = currentBase * 10;
            }
            return index;

        }
    }
}
