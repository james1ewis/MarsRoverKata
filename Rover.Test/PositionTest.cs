using System;
using ClassLibrary2;
using NUnit.Framework;

namespace Rover.Test
{
    [TestFixture]
    public class PositionTest
    {
        [Test]
        public void ToStringMethodShouldReturnThePositionInTheExpectedFormat()
        {
            var expectedPositionString = "2 2";
            var sut = new Position(2, 2);

            Assert.AreEqual(expectedPositionString, sut.ToString());
        }

        [Test]
        public void PositionShouldParseAStringPositionIntoAPositionObject()
        {
            var currentPosition = Position.Parse("2 2");

            Assert.IsInstanceOf<Position>(currentPosition);
            Assert.AreEqual(2, currentPosition.X);
            Assert.AreEqual(2, currentPosition.Y);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PositionShouldNotAttemptToParseEmptyStrings()
        {
            Position.Parse("");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PositionShouldNotAttemptToParseIfInputStringDoesNotContainExpectedXAndYChars()
        {
            Position.Parse("2");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PositionShouldNotAttemptToParseIfCharArrayDoesNotContainExactly2ParsableElements()
        {
            Position.Parse("2 ");
        }
    }
}
