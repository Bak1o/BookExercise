using BookExercise.IteratorPattern;

namespace General.Tests
{
    public class NumbersGeneratorTests
    {
        [Fact]
        public void GenerateNumbers_WithForeach()
        {
            //Arrange
            int count = 5;
            var numbers = new NumbersGenerator(count);
            var result = new List<int>();
            var expectedResult = new List<int> {  1, 2, 3, 4, 5 };

            //Act
            foreach (var number in numbers)
            {
                result.Add(number);
            }
            //Assert
            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void GenerateNumbers_WithEnumerator()
        {
            //Arrange
            NumbersGenerator numbers = new NumbersGenerator(7);
            List<int> result = new List<int>();
            IEnumerator<int> enumerator = numbers.GetEnumerator();
            //act
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }
            //Assert
            Assert.Equal([1,2,3,4,5,6,7], result);


        }

        [Fact]
        public void GenerateNumbers_WithYieldReturn()
        {
            //Arrange
            IEnumerable<int> numbers = Functions.GetNumbers(6);
            var result = new List<int>();
            IEnumerator<int> enumerator = numbers.GetEnumerator();
            //Act
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }
            //Assert
            Assert.Equal([1,2,3,4,5,6], result);



        }
    }

}
