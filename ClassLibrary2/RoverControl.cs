using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary2
{
    public class RoverControl
    {
        private readonly IRoverCollection _rovers;
        
        public RoverControl(IRoverCollection rovers)
        {
            _rovers = rovers;
        }

        public IEnumerable<string> InputCommands(string commands)
        {
            // first part is upper bounds of plateau
            var commandsArray = commands.Split('\n');
            var plateau = Plateau.Parse(commandsArray.First());

            // get rover commands
            var roverCommands = GetRoverCommandsFromString(commandsArray);

            // final location array
            var finalRoverLocations = new List<string>();

            // tell the rovers to move
            foreach (var roverCmd in roverCommands)
            {
                var position = Position.Parse(roverCmd.Location);
                var rover = _rovers.GetForLocation(position.X, position.Y);
                var command = NavigationCommand.Parse(roverCmd.Instructions);
                command.Plateau = plateau;
                rover.ExecuteNavigationCommand(command);
                var finalRoverLocation = rover.GetFinalPosition();
                finalRoverLocations.Add(finalRoverLocation.ToString());
            }

            return finalRoverLocations;
        }

        private IEnumerable<RoverCommand> GetRoverCommandsFromString(string[] commandsArray)
        {
            return new List<RoverCommand> { new RoverCommand { Location = "", Instructions = "" } };
        }
    }

    internal class RoverCommand
    {
        public string Location { get; set; }
        public string Instructions { get; set; }
    }
}
