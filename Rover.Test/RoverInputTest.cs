using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ClassLibrary2;

namespace Rover.Test
{
    [TestFixture]
    public class RoverInputTest
    {
        [Test]
        public void RoverInputShouldContainACollectionOfInputCommands()
        {
            var sut = new RoverInput(new List<InputCommand>());

            Assert.IsInstanceOf<IEnumerable<InputCommand>>(sut.Commands);
        }

        [Test]
        public void RoverInputShouldBeInitializedWithACollectionOfInputCommands()
        {
            var sut = new RoverInput(new List<InputCommand>());

            Assert.Pass();
        }
    }
}
