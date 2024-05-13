using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols.agencyCommands
{
    public class JaxaAgencyCommands : AgencyCommands
    {
        public Command CreateCommand(int displacement, string commandRepresentation)
        {
            return commandRepresentation switch
            {
                "at" => new MovementBackward(displacement),
                "iz" => new RotationLeft(),
                "der" => new RotationRight(),
                _ => new MovementForward(displacement)
            };
        }

        public CommandExtractor GetCommandExtractor()
        {
            return new JaxaCommandExtractor();
        }
    }
}
