using System;

namespace Hello.infrastructure
{
    public class GetCurrentTime : TimeProvider
    {
        public TimeOnly GetTimeOfTheDay()
        {
            return TimeOnly.FromDateTime(DateTime.Now);
        }
    }
}
