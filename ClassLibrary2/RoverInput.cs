using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    public class RoverInput
    {
        public static RoverInput Empty { get { return new RoverInput(new List<InputCommand>()); } }

        public IEnumerable<InputCommand> Commands { get; private set; }

        public RoverInput(IEnumerable<InputCommand> commands)
        {
            Commands = commands;
        }
    }
}
