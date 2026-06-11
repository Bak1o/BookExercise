using BookExercise.Algorithms.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.Tests
{
    public class CountingSortTest
    {
        [Fact]
        public void Sort_NullArray_ThrowsArgumentNullException()
        {
            // Arrange
            int[] arr = null;

            // Act
            Action act = () => RadixSort.Run(arr);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }
        [Fact]
        public void Sort_EmptyArray_ReturnsEmptyArray()
        {
            // Arrange
            int[] arr = Array.Empty<int>();

            // Act
            int[] result = RadixSort.Run(arr);

            // Assert
            Assert.Empty(result);
        }
        [Fact]
        public void Sort_AllPositiveNumbers()
        {
            //Arrange
            int[] arr = { 27, 4, 12, 109, 27, 2, 98 };
            int[] expectedResult = { 2, 4, 12, 27, 27, 98, 109 };
            //Act
            int[] sortedArr = CountingSort.Run(arr);
            //Assert
            Assert.Equal(expectedResult, sortedArr);
        }

        [Fact]
        public void Sort_AllNegativeNumbers()
        {
            //Arrange
            int[] arr = { -27, -4, -12, -109, -27, -2, -98 };
            int[] expectedResult = { -109, -98, -27, -27, -12, -4, -2 };
            //Act
           int[] sortedArr = CountingSort.Run(arr);
            //Assert
            Assert.Equal(expectedResult, sortedArr);
        }
        [Fact]
        public void Sort_MixedSignedNumbers()
        {
            //Arrange
            int[] arr = { 27, 4, -12, 0, 109, -27, 2, 98 };
            int[] expectedResult = { -27, -12, 0, 2, 4, 27, 98, 109 };
            //Act
            int[] sortedArr = CountingSort.Run(arr);
            //Assert
            Assert.Equal(expectedResult, sortedArr);
        }
       
    }
}

