using System;

namespace StockBroker.infrastructure;

public class ConsoleNotifier : Notifier
{
    public void Notify(string message)
    {
        Console.WriteLine(message);
    }
}