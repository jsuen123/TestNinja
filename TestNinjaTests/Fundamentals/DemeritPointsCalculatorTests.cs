using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaTests.Fundamentals
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        {
            //Arrange
            var demeritPointsCalculator = new DemeritPointsCalculator();
           
            //Act & Assert
            Assert.That(() => demeritPointsCalculator.CalculateDemeritPoints(speed),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
                 
        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(73, 1)]
        [TestCase(75, 2)]
        [TestCase(299, 46)]
        [TestCase(300, 47)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int demeritPoints)
        {
            //Arrange
            var demeritPointsCalculator = new DemeritPointsCalculator();
           
            //Act
            var actualResult = demeritPointsCalculator.CalculateDemeritPoints(speed);
            
            //Assert
            Assert.That(actualResult == demeritPoints);
        }
    }
}