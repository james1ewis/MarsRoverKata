using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    public class RoverControl
    {
        public IEnumerable<Rover> Rovers { get; set; }

        public RoverControl()
        {
            Rovers = new List<Rover>();
        }

        public void ExecuteCommand(string command)
        {
            
        }
    }
}
