using System;

namespace Hello;

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