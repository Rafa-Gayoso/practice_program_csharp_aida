namespace ReadBooks;

public class Book
{
    private readonly string _title;

    public Book(string title)
    {
        _title = title;
    }

    protected bool Equals(Book other)
    {
        return _title == other._title;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Book)obj);
    }

    public override int GetHashCode()
    {
        return (_title != null ? _title.GetHashCode() : 0);
    }
}