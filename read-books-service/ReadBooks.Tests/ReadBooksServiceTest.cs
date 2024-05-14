using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace ReadBooks.Tests
{
    public class ReadBooksServiceTest
    {
        private FriendsRepository _friendsRepository;
        private BooksRepository _booksRepository;
        private Session _session;
        private ReadBooksService _readBooksService;

        [SetUp]
        public void Setup()
        {
            _friendsRepository = Substitute.For<FriendsRepository>();
            _booksRepository = Substitute.For<BooksRepository>();
            _session = Substitute.For<Session>();
            _readBooksService = new(_friendsRepository, _session, _booksRepository);
        }

        [Test]
        public void user_is_not_logged_throw_exception()
        {
            _session.GetLoggedUser().ReturnsNull();
            User user = new(Guid.NewGuid());

            Action act = () => _readBooksService.GetBooksReadByUser(user);

            act.Should()
                .Throw<UserNotLoggedException>()
                .WithMessage("The user is not logged");
        }

        [Test]
        public void given_user_and_logged_user_are_not_friends()
        {
            var loggedUser = new User(Guid.NewGuid());
            _session.GetLoggedUser().Returns(loggedUser);
            User requestUser = new(Guid.NewGuid());
            _friendsRepository
                .GetFriendsOf(requestUser.Id)
                .Returns(Enumerable.Empty<User>());

            var booksReadByUser = _readBooksService.GetBooksReadByUser(requestUser);

            booksReadByUser.Should().BeEmpty();
        }

        [Test]
        public void given_user_and_logged_user_are_friends_then_return_read_books_from_given_user()
        {
            var loggerUserId = Guid.NewGuid();
            var loggedUser = new User(loggerUserId);
            _session.GetLoggedUser().Returns(loggedUser);
            User requestUser = new(Guid.NewGuid());
            _friendsRepository
                .GetFriendsOf(requestUser.Id)
                .Returns(new List<User> { new User(loggerUserId) });
            var readBooks = new List<Book> { new Book("Pragmatic programmer") };
            _booksRepository
                .GetBooksReadBy(requestUser.Id)
                .Returns(readBooks);

            var booksReadByUser = _readBooksService.GetBooksReadByUser(requestUser);

            booksReadByUser.Should().BeEquivalentTo(readBooks);
        }
    }
}