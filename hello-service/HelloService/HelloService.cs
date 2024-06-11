using System;

namespace Hello;

public class HelloService
{
    private readonly Notifier _notifier;
    private readonly TimeProvider _timeProvider;

    public HelloService(Notifier notifier)
    {
        _notifier = notifier;
    }

    public HelloService(Notifier notifier, TimeProvider timeProvider)
    {
        _notifier = notifier;
        _timeProvider = timeProvider;
    }

    public void Hello()
    {
        var time = _timeProvider.GetTimeOfTheDay();

        if (IsMorningTime(time))
        {
            _notifier.Notify("Buenos dias!");
            return;
        }

        if (IsEveningTime(time))
        {
            _notifier.Notify("Buenas tardes!");
            return;
        }

        _notifier.Notify("Buenas noches!");
    }

    private bool IsMorningTime(TimeOnly time)
    {
        return time.IsBetween(new TimeOnly(6,0), new TimeOnly(12,0));
    }

    private bool IsEveningTime(TimeOnly time)
    {
        return time.IsBetween(new TimeOnly(12, 1), new TimeOnly(20, 0));
    }
}