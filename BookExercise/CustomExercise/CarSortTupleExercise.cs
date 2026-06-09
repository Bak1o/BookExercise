using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomExercise
{
    internal static class CarSortTupleExercise
    {
        static Dictionary<char, int> dict = new Dictionary<char, int>();
        static char[] lettersOrder = { 'M', 'B', 'T', 'A', 'K', 'O', 'F', 'H', 'V', 'L', 'S', 'N', 'Z', 'Y', 'X', 'W', 'R', 'Q', 'P', 'G', 'D', 'C', 'E', 'U', 'I', 'J' };
        static CarSortTupleExercise()
        {

            int i = 0;
            for (i = 0; i < lettersOrder.Length; i++)
            {

                dict[char.ToLower(lettersOrder[i])] = i;
            }
        }
        public static void Run((string name, int price)[] arr)
        {
            MergeSortAscending(arr, 0, arr.Length - 1);

            int index = FindSplitIndex(arr, 10000);
            if (index != -1)
            {
                MergeSortDescending(arr, index, arr.Length - 1);
            }
            index = 0;
            while (index < arr.Length - 1)
            {
                if (arr[index].price == arr[index + 1].price)
                {
                    int startIndex = index;
                    int endIndex = index + 1;
                    index++;
                    while (index < arr.Length - 1 && (arr[index].price == arr[index + 1].price))
                    {
                        endIndex = index + 1;
                        index++;
                    }
                    SortByName(arr, startIndex, endIndex);

                }
                else
                {
                    index++;
                }
            }

        }
        private static void MergeSortAscending((string name, int price)[] arr, int start, int end)
        {
            if (start >= end)
                return;
            int midd = (start + end) / 2;
            MergeSortAscending(arr, start, midd);
            MergeSortAscending(arr, midd + 1, end);
            MergeAscending(arr, start, midd, end);
        }
        private static void MergeAscending((string name, int price)[] arr, int start, int mid, int end)
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
        private static void MergeSortDescending((string name, int price)[] arr, int start, int end)
        {
            if (start >= end)
                return;
            int midd = (start + end) / 2;
            MergeSortDescending(arr, start, midd);
            MergeSortDescending(arr, midd + 1, end);
            MergeDescending(arr, start, midd, end);
        }
        private static void MergeDescending((string name, int price)[] arr, int start, int mid, int end)
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
                if (leftElement.price >= rightElement.price)
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
        private static int FindSplitIndex((string name, int price)[] sortedArr, int threshold)
        {
            if (sortedArr[0].price > threshold)
                return 0;
            if (sortedArr[sortedArr.Length - 1].price <= threshold)
                return -1;
            for (int i = 1; i < sortedArr.Length; i++)
            {
                if (sortedArr[i - 1].price <= threshold && sortedArr[i].price > threshold)
                    return i;
            }
            return -1;

        }
        private static void SortByName((string name, int price)[] arr, int startIndex, int endIndex)
        {

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                var element = arr[i];
                int index = i;
                while (index > startIndex && MyStringCompare(element.name, arr[index - 1].name) == -1)
                {
                    arr[index] = arr[index - 1];
                    index--;
                }
                arr[index] = element;
            }

        }
        private static int MyStringCompare(string firstElement, string secondElement)
        {
            string firstToLower = firstElement.ToLower();
            string secondToLower = secondElement.ToLower();


            int i = 0;
            while (i < firstElement.Length && i < secondElement.Length)
            {
                if (dict[firstToLower[i]] < dict[secondToLower[i]])
                    return -1;
                if (dict[firstToLower[i]] > dict[secondToLower[i]])
                    return 1;
                i++;
            }
            if (firstToLower.Length < secondToLower.Length)
                return -1;
            if (firstToLower.Length > secondToLower.Length)
                return 1;
            return 0;




        }
    }
}
