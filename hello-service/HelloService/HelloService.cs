using System;

namespace Hello;

public class HelloService
{
    private readonly Notifier _notifier;
    private readonly TimeProvider _timeProvider;
    private static TimeInterval _morning;
    private static TimeInterval _evening;

    public HelloService(Notifier notifier, TimeProvider timeProvider)
    {
        _notifier = notifier;
        _timeProvider = timeProvider;
        _morning = new TimeInterval(new TimeOnly(6, 0), new TimeOnly(12, 0));
        _evening = new TimeInterval(new TimeOnly(12, 1), new TimeOnly(20, 0));
    }

    public void Hello()
    {
        _notifier.Notify(Greet());
    }

    private string Greet()
    {
        var time = _timeProvider.GetTimeOfTheDay();

        var message = "Buenas noches!";

        if (_morning.Contains(time))
        {
            message = "Buenos dias!";
        }
         
        if (_evening.Contains(time))
        {
            message = "Buenas tardes!";
        }
        
        return message;
    }
}