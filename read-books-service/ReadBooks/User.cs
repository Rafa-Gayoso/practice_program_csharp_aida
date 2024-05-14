using System;

namespace ReadBooks;

public class User
{
    public Guid Id { get; init; }

    public User(Guid id)
    {
        Id = id;
    }

    protected bool Equals(User other)
    {
        return Id.Equals(other.Id);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((User)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}