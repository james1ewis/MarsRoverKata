using NUnit.Framework;

namespace Rover.Test.IntegrationTests
{
    [TestFixture]
    public class RoverIntegrationTests
    {
        [Test]
        public void TestScenarioFromKata1()
        {
            var sut = new ClassLibrary2.Rover("1 2", "N", "5 5");
            var result = sut.ReceiveDirectionInstructions("LMLMLMLMM");
            var expectedResult = "1 3 N";

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestScenarioFromKata2()
        {
            var sut = new ClassLibrary2.Rover("3 3", "E", "5 5");
            var result = sut.ReceiveDirectionInstructions("MMRMMRMRRM");
            var expectedResult = "5 1 E";

            Assert.AreEqual(expectedResult, result);
        }
    }
}
