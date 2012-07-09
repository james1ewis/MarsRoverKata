using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassLibrary2
{
    public class ReceivedMessageTransaltor : IReceivedMessageTranslator
    {
        public char[] InputArray { get; private set; }
        public IEnumerable<InputCommand> InputCommandCollection { get; set; }

        public RoverInput Translate(string input)
        {
            InputArray = input.ToCharArray();

            InputCommandCollection = TranslateInputCharsIntoInputCommands(InputArray);

            return RoverInput.Empty;
        }

        private IEnumerable<InputCommand> TranslateInputCharsIntoInputCommands(char[] inputArray)
        {

            return from inputChar in inputArray
                   select TranslateInputCharIntoInputCommand(inputChar);
        }

        private InputCommand TranslateInputCharIntoInputCommand(char inputChar)
        {
            switch (inputChar)
            {
                case 'L': return InputCommand.Left;
                case 'M': return InputCommand.Move;
                case 'R': return InputCommand.Right;
                default: return InputCommand.Default;
            }
        }
    }
}
