using System;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    public class Rover
    {
        public IReceivedMessageTranslator ReceivedMessageTranslator { get; private set; }
        public Position CurrentPosition { get; private set; }
        public Heading CurrentHeading { get; private set; }
        public NavigationCommand Input { get; private set; }
        public IPlateau PlanetPlateau { get; private set; }

        public Rover(string position, string heading, string plateauUpperBounds)
            : this(position, heading, plateauUpperBounds, new ReceivedMessageTransaltor()) { }

        public Rover(string position, string heading, string plateauUpperBounds, IReceivedMessageTranslator translator)
        {
            CurrentPosition = Position.Parse(position);
            CurrentHeading = Heading.Parse(heading);
            PlanetPlateau = Plateau.Parse(plateauUpperBounds);

            ReceivedMessageTranslator = translator;
        }

        // this is the main entry point of the class used to handle input from an external source (NASA).
        public string ReceiveDirectionInstructions(string instructions)
        {
            Input = ReceivedMessageTranslator.Translate(instructions);

            ExecuteInputCommands();

            return TranslatePositionAndHeadingIntoString();
        }

        private void ExecuteInputCommands()
        {
            foreach (var command in Input.Commands)
            {
                ExecuteInputCommand(command);
            }
        }

        private void ExecuteInputCommand(InputCommand command)
        {
            switch (command)
            {
                case InputCommand.Left:
                    CurrentHeading = (CurrentHeading.HeadingEnum == HeadingEnum.North) ? new Heading(HeadingEnum.West) : CurrentHeading = new Heading(CurrentHeading.HeadingEnum - 1);
                    break;
                case InputCommand.Right:
                    CurrentHeading = (CurrentHeading.HeadingEnum == HeadingEnum.West) ? new Heading(HeadingEnum.North) : CurrentHeading = new Heading(CurrentHeading.HeadingEnum + 1);
                    break;
                case InputCommand.Move:
                    switch (CurrentHeading.HeadingEnum)
                    {
                        case HeadingEnum.North:
                            CurrentPosition = (CurrentPosition.Y == PlanetPlateau.UpperY) ? CurrentPosition : new Position(CurrentPosition.X, CurrentPosition.Y + 1);
                            break;
                        case HeadingEnum.East:
                            CurrentPosition = (CurrentPosition.X == PlanetPlateau.UpperX) ? CurrentPosition : new Position(CurrentPosition.X + 1, CurrentPosition.Y);
                            break;
                        case HeadingEnum.South:
                            CurrentPosition = (CurrentPosition.Y == PlanetPlateau.LowerY) ? CurrentPosition : new Position(CurrentPosition.X, CurrentPosition.Y - 1);
                            break;
                        case HeadingEnum.West:
                            CurrentPosition = (CurrentPosition.X == PlanetPlateau.LowerX) ? CurrentPosition : new Position(CurrentPosition.X - 1, CurrentPosition.Y);
                            break;
                        default: break;
                    }
                    break;
                default: break;
            }
        }

        private string TranslatePositionAndHeadingIntoString()
        {
            var builder = new StringBuilder();
            builder.Append(CurrentPosition);
            builder.Append(" ");
            builder.Append(CurrentHeading);

            return builder.ToString();
        }




        private readonly IPositionController _positionController;

        internal void ExecuteNavigationCommand(NavigationCommand command)
        {
            foreach (var navCommand in command.Commands)
            {
                if (navCommand == InputCommand.Move)
                    _positionController.ProgressPosition();
                else
                    _positionController.AdjustHeading(navCommand);
            }
        }

        internal Position GetFinalPosition()
        {
            return new Position(_positionController.CurrentX, _positionController.CurrentY);
        }
    }
}
