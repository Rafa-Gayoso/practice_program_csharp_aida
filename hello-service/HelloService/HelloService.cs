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
        var time = _timeProvider.GetTimeOfTheDay();

        if (Morning().Contains(time))
        {
            _notifier.Notify("Buenos dias!");
        }
        else if (Evening().Contains(time))
        {
            _notifier.Notify("Buenas tardes!");
        }
        else
        {
            _notifier.Notify("Buenas noches!");
        }
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

public class TimeInterval
{
    private readonly TimeOnly _from;
    private readonly TimeOnly _to;

    public TimeInterval(TimeOnly from, TimeOnly to)
    {
        _from = from;
        _to = to;
    }

    public bool Contains(TimeOnly time)
    {
        return time.IsBetween(_from, _to);
    }
}