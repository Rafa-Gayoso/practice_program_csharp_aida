using System.Collections.Generic;
using System.Linq;

namespace MarsRover.communicationProtocols;

public class CommunicationProtocolForAgency : CommunicationProtocol
{
    private readonly AgencyCommands _agencyCommands;

    public CommunicationProtocolForAgency( AgencyCommands agencyCommands)
    {
        _agencyCommands = agencyCommands;
    }
    public override List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        var commandRepresentations = _agencyCommands.GetCommandExtractor().Extract(commandsSequence);
        return commandRepresentations
            .Select(commandRepresentation => _agencyCommands.CreateCommand(displacement, commandRepresentation))
            .ToList();
    }
}