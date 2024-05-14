using System.Collections.Generic;

namespace ReadBooks;

public class ReadBooksService
{
    private readonly DataPersistence _dataPersistence;
    private readonly Session _session;

    public ReadBooksService(DataPersistence dataPersistence, Session session)
    {
        _dataPersistence = dataPersistence;
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