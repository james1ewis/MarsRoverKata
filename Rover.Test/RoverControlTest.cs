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
            var sut = new RoverControl();
            sut.ExecuteCommand(string.Empty);

            Assert.Pass();
        }
    }
}
