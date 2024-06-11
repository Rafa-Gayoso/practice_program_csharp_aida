using System;

namespace Hello;

public class HelloService
{
    private readonly Notifier _notifier;
    private readonly TimeProvider _timeProvider;

    public HelloService(Notifier notifier, TimeProvider timeProvider)
    {
        _notifier = notifier;
        _timeProvider = timeProvider;
    }

    public void Hello()
    {
        _notifier.Notify(Greet());
    }

    private string Greet()
    {
        var time = _timeProvider.GetTimeOfTheDay();

        var message = "Buenas noches!";

        if (Morning().Contains(time))
        {
            message = "Buenos dias!";
        }
        else if (Evening().Contains(time))
        {
            message = "Buenas tardes!";
        }

        return message;
    }

    private static TimeInterval Morning()
    {
        return new TimeInterval(new TimeOnly(6, 0), new TimeOnly(12, 0));
    }

    private static TimeInterval Evening()
    {
        return new TimeInterval(new TimeOnly(12, 1), new TimeOnly(20, 0));
    }
}