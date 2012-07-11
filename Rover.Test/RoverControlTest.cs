using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ClassLibrary2;

namespace Rover.Test
{
    [TestFixture]
    public class RoverControlTest
    {
        [Test]
        public void RoverControlShouldExposeAnExecuteCommandMethodThatTakesAStringAsInput()
        {
            var sut = new RoverControl(new List<ClassLibrary2.Rover>());
            sut.ExecuteCommand(string.Empty);

            Assert.Pass();
        }

        [Test]
        public void RoverControlShouldBeInitializedWithACollectionOfRovers()
        {
            var sut = new RoverControl(new List<ClassLibrary2.Rover>());

            Assert.Pass();
        }
    }
}
