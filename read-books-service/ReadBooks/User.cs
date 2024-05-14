using System;

namespace ReadBooks;

public class User
{
    public Guid Id { get; init; }

    public User(Guid id)
    {
        Id = id;
    }
}