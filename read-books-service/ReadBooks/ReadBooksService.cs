using System.Collections.Generic;
using System.Linq;

namespace ReadBooks;

public class ReadBooksService
{
    private readonly FriendsRepository _friendsRepository;
    private readonly Session _session;
    private readonly BooksRepository _booksRepository;

    public ReadBooksService(FriendsRepository friendsRepository, Session session, BooksRepository booksRepository)
    {
        _friendsRepository = friendsRepository;
        _session = session;
        _booksRepository = booksRepository;
    }

    public List<Book> GetBooksReadByUser(User user)
    {
        var loggedUser = _session.GetLoggedUser();

        if (loggedUser is null)
        {
            throw new UserNotLoggedException("The user is not logged");
        }

        var friends = _friendsRepository.GetFriendsOf(user.Id);
        if (friends.Contains(loggedUser))
        {
            return _booksRepository.GetBooksReadBy(user.Id);
        }

        return new List<Book>();
    }
}