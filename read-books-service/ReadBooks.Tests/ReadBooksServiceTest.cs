using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace ReadBooks.Tests
{
    public class ReadBooksServiceTest
    {
        [Test]
        public void user_is_not_logged_throw_exception()
        {
            DataPersistence _dataPersistence = Substitute.For<DataPersistence>();
            Session session = Substitute.For<Session>();
            session.GetLoggedUser().ReturnsNull();
            ReadBooksService readBooksService = new(_dataPersistence, session);
            User user = new(Guid.NewGuid());

            Action act = () => readBooksService.GetBooksReadByUser(user);

            act.Should()
                .Throw<UserNotLoggedException>()
                .WithMessage("The user is not logged");
        }

        [Test]
        public void given_user_and_logged_user_are_not_friends()
        {
            DataPersistence _dataPersistence = Substitute.For<DataPersistence>();
            Session session = Substitute.For<Session>();
            ReadBooksService readBooksService = new(_dataPersistence, session);
            var loggedUser = new User(Guid.NewGuid());
            session.GetLoggedUser().Returns(loggedUser);
            User requestUser = new(Guid.NewGuid());
            _dataPersistence
                .GetFriendsOf(requestUser.Id)
                .Returns(Enumerable.Empty<User>());

            var booksReadByUser = readBooksService.GetBooksReadByUser(requestUser);

            booksReadByUser.Should().BeEmpty();
        }
    }
}