using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols.agencyCommands
{
    public class CnsaAgencyCommands : AgencyCommands
    {
        public Command CreateCommand(int displacement, string commandRepresentation)
        {
            return commandRepresentation switch
            {
                "bx" => new MovementForward(displacement),
                "tf" => new MovementBackward(displacement),
                "ah" => new RotationLeft(),
                _ => new RotationRight()
            };
        }

        public CommandExtractor GetCommandExtractor()
        {
            return new FixedLengthCommandExtractor(2);
        }
    }
}
