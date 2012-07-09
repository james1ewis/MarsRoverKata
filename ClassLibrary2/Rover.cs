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
        public RoverInput Input { get; private set; }

        public Rover(string position, string heading)
            : this(position, heading, new ReceivedMessageTransaltor()) { }

        public Rover(string position, string heading, IReceivedMessageTranslator translator)
        {
            CurrentPosition = Position.Parse(position);
            CurrentHeading = Heading.Parse(heading);

            ReceivedMessageTranslator = translator;
        }

        // this is the main entry point of the class used to handle input from an external source (NASA).
        public string ReceiveDirectionInstructions(string instructions)
        {
            Input = ReceivedMessageTranslator.Translate(instructions);

            foreach (var command in Input.Commands)
            {
                switch (command)
                {
                    case InputCommand.Left:
                        switch (CurrentHeading.HeadingEnum)
                        {
                            case HeadingEnum.North:
                                CurrentHeading = new Heading(HeadingEnum.West);
                                break;
                            case HeadingEnum.East:
                                CurrentHeading = new Heading(HeadingEnum.North);
                                break;
                            case HeadingEnum.South:
                                CurrentHeading = new Heading(HeadingEnum.East);
                                break;
                            case HeadingEnum.West:
                                CurrentHeading = new Heading(HeadingEnum.South);
                                break;
                            default: break;
                        }
                        break;
                    case InputCommand.Right:
                        switch (CurrentHeading.HeadingEnum)
                        {
                            case HeadingEnum.North:
                                CurrentHeading = new Heading(HeadingEnum.East);
                                break;
                            case HeadingEnum.East:
                                CurrentHeading = new Heading(HeadingEnum.South);
                                break;
                            case HeadingEnum.South:
                                CurrentHeading = new Heading(HeadingEnum.West);
                                break;
                            case HeadingEnum.West:
                                CurrentHeading = new Heading(HeadingEnum.North);
                                break;
                            default: break;
                        }
                        break;
                    case InputCommand.Move:
                        switch (CurrentHeading.HeadingEnum)
                        {
                            case HeadingEnum.North:
                                CurrentPosition = new Position(CurrentPosition.X, CurrentPosition.Y + 1);
                                break;
                            case HeadingEnum.East:
                                CurrentPosition = new Position(CurrentPosition.X + 1, CurrentPosition.Y);
                                break;
                            case HeadingEnum.South:
                                CurrentPosition = new Position(CurrentPosition.X, CurrentPosition.Y - 1);
                                break;
                            case HeadingEnum.West:
                                CurrentPosition = new Position(CurrentPosition.X - 1, CurrentPosition.Y);
                                break;
                            default: break;
                        }
                        break;
                    default: break;

                }
            }

            return TranslatePositionAndHeadingIntoString();
        }

        private string TranslatePositionAndHeadingIntoString()
        {
            var builder = new StringBuilder();
            builder.Append(CurrentPosition);
            builder.Append(" ");
            builder.Append(CurrentHeading);

            return builder.ToString();
        }
    }
}
