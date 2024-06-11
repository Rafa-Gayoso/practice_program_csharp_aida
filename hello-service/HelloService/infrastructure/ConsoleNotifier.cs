using System;

namespace Hello.infrastructure;

public class ConsoleNotifier : Notifier
{
    public void Notify(string message)
    {
        Console.WriteLine(message);
    }
}