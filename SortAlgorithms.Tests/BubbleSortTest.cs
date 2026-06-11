using BookExercise.Algorithms.SortingAlgorithms;
namespace SortAlgorithms.Tests
{
    public class BubbleSortTest
    {
        [Fact]
        public void Sort_AllPositiveNumbers()
        {
            //Arrange
            int[] arr = { 27, 4, 12, 109, 27, 2, 98 };
            int[] expectedResult = { 2, 4, 12, 27, 27, 98, 109 };
            //Act
            BubbleSort.Run(arr);
            //Assert
            Assert.Equal(expectedResult, arr);
        }

        [Fact]
        public void Sort_AllNegativeNumbers()
        {
            //Arrange
            int[] arr = { -27, -4, -12, -109, -27, -2, -98 };
            int[] expectedResult = {- 109, -98, -27, -27, -12, -4, -2 };
            //Act
            BubbleSort.Run(arr);
            //Assert
            Assert.Equal(expectedResult, arr);
        }
        [Fact]
        public void Sort_MixedSignedNumbers()
        {
            //Arrange
            int[] arr = { 27, 4, -12, 0, 109, -27, 2, 98};
            int[] expectedResult = {-27, -12, 0, 2, 4, 27, 98, 109 };
            //Act
            BubbleSort.Run(arr);
            //Assert
            Assert.Equal(expectedResult, arr);
        }
    }
}
