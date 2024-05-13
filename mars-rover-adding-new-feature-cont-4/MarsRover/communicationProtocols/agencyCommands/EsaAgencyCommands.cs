using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols.agencyCommands
{
    public class EsaAgencyCommands : AgencyCommands
    {
        public Command CreateCommand(int displacement, string commandRepresentation)
        {
            return commandRepresentation switch
            {
                "b" => new MovementForward(displacement),
                "x" => new MovementBackward(displacement),
                "f" => new RotationLeft(),
                _ => new RotationRight()
            };
        }

        public CommandExtractor GetCommandExtractor()
        {
            return new FixedLengthCommandExtractor(1);
        }
    }
}
