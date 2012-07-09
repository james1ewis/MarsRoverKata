using System;
using ClassLibrary2;
using NUnit.Framework;

namespace Rover.Test
{
    [TestFixture]
    public class HeadingTest
    {
        [Test]
        public void ToStringMethodShouldReturnTheStringRepresentationOfTheHeadingEnum()
        {
            var expectedHeadingString = "N";
            var sut = new Heading(HeadingEnum.North);

            Assert.AreEqual(expectedHeadingString, sut.ToString());
        }

        [Test]
        public void HeadingShouldParseAStringHeadingIntoAHeadingObject()
        {
            var currentHeading = Heading.Parse("N");

            Assert.IsInstanceOf<Heading>(currentHeading);
            Assert.AreEqual(HeadingEnum.North, currentHeading.HeadingEnum);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HeadingShouldNotAttemptToParseEmptyStrings()
        {
            Heading.Parse("");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HeadingShouldNotAttemptToParseIfInputStringDoesNotContainExpectedHeadingString()
        {
            Heading.Parse("R");
        }
    }
}
