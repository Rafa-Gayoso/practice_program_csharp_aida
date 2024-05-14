using System;

namespace ReadBooks;

public class User
{
    private readonly Guid _id;

    public User(Guid id)
    {
        _id = id;
    }
}