using System.Collections.Generic;

namespace ReadBooks;

public class ReadBooksService
{
    private readonly BooksRepository _booksRepository;
    private readonly Session _session;

    public ReadBooksService(BooksRepository booksRepository, Session session)
    {
        _booksRepository = booksRepository;
        _session = session;
    }

    public List<Book> GetBooksReadByUser(User user)
    {
        var loggedUser = _session.GetLoggedUser();

        if (loggedUser is null)
        {
            throw new UserNotLoggedException("The user is not logged");
        }

        return new List<Book>();
    }
}