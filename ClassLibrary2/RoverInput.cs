using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    public class NavigationCommand
    {
        public IEnumerable<InputCommand> Commands { get; private set; }
        public IPlateau Plateau { get; set; }

        public NavigationCommand(IEnumerable<InputCommand> commands)
        {
            Commands = commands;
        }

        public static NavigationCommand Empty { get { return new NavigationCommand(new List<InputCommand>()); } }

        public static NavigationCommand Parse(string input)
        {
            return new NavigationCommand(TranslateInputCharsIntoInputCommands(input.ToCharArray()));        
        }

        private static IEnumerable<InputCommand> TranslateInputCharsIntoInputCommands(char[] inputArray)
        {
            return from inputChar in inputArray
                   select TranslateInputCharIntoInputCommand(inputChar);
        }

        private static InputCommand TranslateInputCharIntoInputCommand(char inputChar)
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
