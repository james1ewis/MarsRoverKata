using System;
using ClassLibrary2;
using NUnit.Framework;

namespace Rover.Test
{
    [TestFixture]
    public class PlateauTest
    {
        [Test]
        public void PlateauShouldHaveAParseMethodThatTakesAStringAndReturnsAnIPlateau()
        {
            var result = Plateau.Parse("2 2");
            Assert.IsInstanceOf<IPlateau>(result);
        }

        [Test]
        public void PlateagShouldParseAStringOfUpperBoundsIntoAPlateauObject()
        {
            var plateau = Plateau.Parse("2 2");

            Assert.AreEqual(2, plateau.UpperX);
            Assert.AreEqual(2, plateau.UpperY);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlateauShouldNotAttemptToParseEmptyStrings()
        {
            Plateau.Parse("");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlateauShouldNotAttemptToParseIfInputStringDoesNotContainExpectedXAndYChars()
        {
            Plateau.Parse("2");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlateauShouldNotAttemptToParseIfCharArrayDoesNotContainExactly2ParsableElements()
        {
            Plateau.Parse("2 ");
        }
    }
}
