using System;

namespace Hello;

public interface TimeProvider
{
    TimeOnly GetTimeOfTheDay();
}