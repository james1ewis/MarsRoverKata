using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    public class RoverControl
    {
        public IList<Rover> Rovers { get; set; }

        public RoverControl()
        {
            Rovers = new List<Rover>();
        }

        public void ExecuteCommand(string command)
        {
            var indys = command.Split('\n');
            foreach (var woo in indys)
            {
                var output = new Rover("2 2", "N", "5 5").ReceiveDirectionInstructions(woo);
            }
        }
    }
}
