namespace MarsRover.communicationProtocols;

public interface AgencyCommands
{
    public Command CreateCommand(int displacement, string commandRepresentation);
    public CommandExtractor GetCommandExtractor();
}