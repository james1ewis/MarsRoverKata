using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ClassLibrary2;

namespace Rover.Test
{
    [TestFixture]
    public class ReceivedMessageTransaltorTest
    {
        [Test]
        public void TranslateMethodShouldReturnARoverInputObject()
        {
            var sut = new ReceivedMessageTransaltor();
            var input = sut.Translate(string.Empty);

            Assert.IsInstanceOf<RoverInput>(input);
        }

        [Test]
        public void TranslateMethodShouldSplitTheStringIntoACharArray()
        {
            var sut = new ReceivedMessageTransaltor();
            sut.Translate("LMLMLMLMM");

            Assert.IsInstanceOf<char[]>(sut.InputArray);
            CollectionAssert.AreEquivalent("LMLMLMLMM".ToCharArray(), sut.InputArray);
        }

        [Test]
        public void TranslateMethodShouldCreateAnInputCommandForEachOfTheInputChars()
        {
            var sut = new ReceivedMessageTransaltor();
            sut.Translate("LM");

            CollectionAssert.AreEquivalent(new List<InputCommand> { InputCommand.Left, InputCommand.Move }, sut.InputCommandCollection);
        }

        [Test]
        public void TheInputCommandCollectionShouldBeOrderedTheSameAsTheCharsInTheArray()
        {
            var sut = new ReceivedMessageTransaltor();
            sut.Translate("ML");

            CollectionAssert.AreEqual(new List<InputCommand> { InputCommand.Move, InputCommand.Left }, sut.InputCommandCollection);
        }

        [Test]
        public void TranslateMethodShouldBeAbleToTranslateAllKnownInputChars()
        {
            var sut = new ReceivedMessageTransaltor();
            sut.Translate("LMRM");

            CollectionAssert.AreEqual(new List<InputCommand> { InputCommand.Left, InputCommand.Move, InputCommand.Right, InputCommand.Move }, sut.InputCommandCollection);
        }
    }
}
