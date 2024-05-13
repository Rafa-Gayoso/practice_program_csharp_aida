using System;
using System.Collections.Generic;

namespace MarsRover.communicationProtocols;

public class JointCommunicationProtocol : CommunicationProtocol
{
    public override List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        if (commandsSequence == string.Empty)
        {
            return new List<Command>();
        }
        var protocolIdentifier = commandsSequence.Substring(0, 1);
        var communicationProtocol = IdentifyCommunicationProtocol(protocolIdentifier);

        return communicationProtocol.CreateCommands(commandsSequence.Substring(1), displacement);

    }

    private CommunicationProtocol IdentifyCommunicationProtocol(string protocolIdentifier)
    {
        if (protocolIdentifier == "*")
        {
            return CreateEsaCommunicationProtocol();
        }

        if (protocolIdentifier == "%")
        {
            return CreateCnsaCommunicationProtocol();
        }

        if (protocolIdentifier == "+")
        {
            return CreateJaxaCommunicationProtocol();
        }

        if (protocolIdentifier == "$")
        {
            return CreateNasaCommunicationProtocol();
        }

        return new UnknownProtocol();

    }
}