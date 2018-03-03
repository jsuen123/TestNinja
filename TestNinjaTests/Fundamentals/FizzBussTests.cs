using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaTests.Fundamentals
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(15, "FizzBuzz" )]
        [TestCase(12, "Fizz")]
        [TestCase(55, "Buzz")]
        [TestCase(56, "56")]
        [TestCase(0, "FizzBuzz")]
        public void GetOutput_WhenPassInNumber_ReturnResult(int number, string expected)
        {
            //Act
            var actual = FizzBuzz.GetOutput(number);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        
    }
}