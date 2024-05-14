using System;

namespace ReadBooks;

public class UserNotLoggedException : Exception
{
    public UserNotLoggedException(string? message) : base(message)
    {
    }
}