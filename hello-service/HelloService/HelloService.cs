namespace Hello;

public class HelloService
{
    private readonly Notifier _notifier;

    public HelloService(Notifier notifier)
    {
        _notifier = notifier;
    }

    public void Hello()
    {
        _notifier.Notify("Buenas noches!");
    }
}