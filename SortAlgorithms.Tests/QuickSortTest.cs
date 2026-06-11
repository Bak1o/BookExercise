using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookExercise.Algorithms.SortingAlgorithms;

namespace SortAlgorithms.Tests
{
    public class QuickSortTest
    {
        [Fact]
        public void Sort_NullArray_ThrowsArgumentNullException()
        {
            //Arrange
            int[] arr = null;
            //Act
            Action action = () => QuickSort.Run(arr);
            //Assert
            Assert.Throws<ArgumentNullException>(action);
        }
        [Fact]

        public void Sort_EmptyArray()
        {
            //Arrange
            int[] arr = Array.Empty<int>();
            //Act
            QuickSort.Run(arr);
            //Assert
            Assert.Empty(arr);
        }
        [Fact]
        public void Sort_AllPositiveNumbers()
        {
            //Arrange
            int[] arr = { 27, 4, 12, 109, 27, 2, 98 };
            int[] expectedResult = { 2, 4, 12, 27, 27, 98, 109 };
            //Act
            QuickSort.Run(arr);
            //Assert
            Assert.Equal(expectedResult, arr);
        }

        [Fact]
        public void Sort_AllNegativeNumbers()
        {
            //Arrange
            int[] arr = { -27, -4, -12, -109, -27, -2, -98 };
            int[] expectedResult = { -109, -98, -27, -27, -12, -4, -2 };
            //Act
            QuickSort.Run(arr);
            //Assert
            Assert.Equal(expectedResult, arr);
        }
        [Fact]
        public void Sort_MixedSignedNumbers()
        {
            //Arrange
            int[] arr = { 27, 4, -12, 0, 109, -27, 2, 98 };
            int[] expectedResult = { -27, -12, 0, 2, 4, 27, 98, 109 };
            //Act
            QuickSort.Run(arr);
            //Assert
            Assert.Equal(expectedResult, arr);
        }

    }
}
