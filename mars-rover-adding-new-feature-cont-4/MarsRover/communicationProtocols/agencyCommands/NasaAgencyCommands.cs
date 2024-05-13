using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols.agencyCommands;

public class NasaAgencyCommands : AgencyCommands
{
    public Command CreateCommand(int displacement, string commandRepresentation)
    {
        return commandRepresentation switch
        {
            "l" => new RotationLeft(),
            "r" => new RotationRight(),
            "f" => new MovementForward(displacement),
            _ => new MovementBackward(displacement)
        };
    }

    public CommandExtractor GetCommandExtractor()
    {
        return new FixedLengthCommandExtractor(1);
    }
}