using System.Collections.Generic;
using ClassLibrary2;
using NUnit.Framework;

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

            Assert.IsInstanceOf<NavigationCommand>(input);
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

        [Test]
        public void TranslateMethodShouldReturnARoverInputObjectContainingTheTranslatedCommands()
        {
            var expectedRoverInput = new NavigationCommand(new List<InputCommand> { InputCommand.Left, InputCommand.Move, InputCommand.Right });
            var sut = new ReceivedMessageTransaltor();
            var actualRoverInput = sut.Translate("LMR");

            Assert.AreEqual(expectedRoverInput.Commands, actualRoverInput.Commands);
        }
    }
}
