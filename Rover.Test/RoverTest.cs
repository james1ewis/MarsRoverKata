using System.Collections.Generic;
using ClassLibrary2;
using NUnit.Framework;

namespace Rover.Test
{
    [TestFixture]
    public class RoverTest
    {
        [Test]
        public void RoverShouldAcceptDirectionInstructionsAsString()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);
            sut.ReceiveDirectionInstructions("");

            Assert.Pass();
        }

        [Test]
        public void RoverShouldReturnItsNewPositionAsAString()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);
            var newPosition = sut.ReceiveDirectionInstructions("");

            Assert.IsInstanceOf<string>(newPosition);
        }

        [Test]
        public void RoverShouldKeepTrackOfItsCurrentPosition()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);
            var currentPosition = sut.CurrentPosition;

            Assert.Pass();
        }

        [Test]
        public void RoverShouldSetItsCurrentPositionAfterACompletedMove()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);
            sut.ReceiveDirectionInstructions("");

            Assert.IsNotNull(sut.CurrentPosition);
        }


        [Test]
        public void RoverShouldKeepTrackOfItsCurrentHeading()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);

            var heading = sut.CurrentHeading;

            Assert.Pass();
        }

        [Test]
        public void RoverShouldSetItsCurrentHeadingAfterACompletedMove()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);
            sut.ReceiveDirectionInstructions("");

            Assert.IsNotNull(sut.CurrentHeading);
        }

        [Test]
        public void ShouldBeAbleToInitializeRoverCurrentPositionAndHeading()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);

            Assert.IsNotNull(sut.CurrentHeading);
            Assert.IsNotNull(sut.CurrentPosition);
        }

        [Test]
        public void RoverShouldUpdateCurrentPositionGivenASetOfInstructions()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);
            
            mockTranslator.TranslateReturnObject = new RoverInput(new List<InputCommand>{ InputCommand.Left,InputCommand.Move,InputCommand.Left,InputCommand.Move,InputCommand.Left,InputCommand.Move,InputCommand.Left,InputCommand.Move,InputCommand.Move });

            sut.ReceiveDirectionInstructions("LMLMLMLMM");

            var position = sut.CurrentPosition;
            var expectedPosition = new ClassLibrary2.Position(2, 3);

            Assert.AreEqual(expectedPosition.X, position.X);
            Assert.AreEqual(expectedPosition.Y, position.Y);
        }

        [Test]
        public void RoverShouldUpdateCurrentHeadingGivenASetOfInstructions()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);

            mockTranslator.TranslateReturnObject = new RoverInput(new List<InputCommand> { InputCommand.Left, InputCommand.Move });

            sut.ReceiveDirectionInstructions("LM");

            var heading = sut.CurrentHeading;
            var expectedHeading = HeadingEnum.West;

            Assert.AreEqual(expectedHeading, heading.HeadingEnum);
        }

        [Test]
        public void RoverShouldCallATranslatorToTranslateTheRecevievedInput()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);

            sut.ReceiveDirectionInstructions("LMLMLMLMM");

            Assert.IsTrue(mockTranslator.TranslateMethodWasCalled);
            Assert.IsInstanceOf<string>(mockTranslator.TranslateMethodParameterValue);
        }

        [Test]
        public void RoverShouldCallATranslatorWithTheReceivedInstructionsToGetTheInput()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);

            sut.ReceiveDirectionInstructions("LMLMLMLMM");

            Assert.AreEqual("LMLMLMLMM", mockTranslator.TranslateMethodParameterValue);
        }

        [Test]
        public void RoverShouldCallTranslatorWithTheReceivedInstructionsAndStoreTheReturnedRoverInput()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);
            mockTranslator.TranslateReturnObject = new RoverInput(new List<InputCommand> { InputCommand.Left, InputCommand.Move });

            sut.ReceiveDirectionInstructions("LM");

            Assert.IsInstanceOf<RoverInput>(sut.Input);
            Assert.AreEqual(mockTranslator.TranslateReturnObject, sut.Input);
        }

        [Test]
        public void RoverShouldReturnItsCurrentPositionAsAStringAfterProcessingASetOfInstructions()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);
            mockTranslator.TranslateReturnObject = new RoverInput(new List<InputCommand> { InputCommand.Left, InputCommand.Move });

            var returnedPosition = sut.ReceiveDirectionInstructions("LM");

            Assert.AreEqual("1 2 W", returnedPosition);
        }

        [Test]
        public void RoverShouldBeInitializedWithUpperBoundsOfPlateau()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);
            Assert.Pass();
        }

        [Test]
        public void RoverShouldParseThePlateauUpperBoundsDuringInitialization()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "5 5", mockTranslator);

            var parsedBounds = sut.PlanetPlateau;

            Assert.IsInstanceOf<IPlateau>(parsedBounds);
            Assert.AreEqual(5, parsedBounds.UpperX);
            Assert.AreEqual(5, parsedBounds.UpperY);
        }

        [Test]
        public void RoverShouldNotExecuteAnInputCommandIfItWillTakeItOverTheEdgeOfThePlateau()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("2 2", "N", "2 2", mockTranslator);
            mockTranslator.TranslateReturnObject = new RoverInput(new List<InputCommand> { InputCommand.Left, InputCommand.Move, InputCommand.Right, InputCommand.Move });
            
            var returnedPosition = sut.ReceiveDirectionInstructions("LMRM");

            Assert.AreEqual("1 2 N", returnedPosition);
        }
        
        [Test]
        public void RoverShouldNotExecuteAnInputCommandIfItWillTakeItBelowTheLowerBoundsOfThePlateau()
        {
            var mockTranslator = new MockTranslator();
            var sut = new ClassLibrary2.Rover("0 0", "S", "2 2", mockTranslator);
            mockTranslator.TranslateReturnObject = new RoverInput(new List<InputCommand> { InputCommand.Move, InputCommand.Move, InputCommand.Left, InputCommand.Move });

            var returnedPosition = sut.ReceiveDirectionInstructions("MMRM");

            Assert.AreEqual("1 0 E", returnedPosition);
        }
    }
}
