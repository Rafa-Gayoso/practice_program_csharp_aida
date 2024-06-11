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
        var time = _timeProvider.GetTime();
        if (time.IsBetween(new TimeOnly(6,0,0),new TimeOnly(12,0,0)))
        {
            _notifier.Notify("Buenos dias!");
        }
        _notifier.Notify("Buenas noches!");
    }
}