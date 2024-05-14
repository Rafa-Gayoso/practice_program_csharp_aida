namespace ReadBooks;

public class ReadBooksService
{
    private readonly DataPersistence _dataPersistence;
    private readonly SessionObject _sessionObject;

    public ReadBooksService(DataPersistence dataPersistence, SessionObject sessionObject)
    {
        _dataPersistence = dataPersistence;
        _sessionObject = sessionObject;
    }

    public void GetBooksReadByUser(User user)
    {
        throw new UserNotLoggedException("The user is not logged");
    }
}