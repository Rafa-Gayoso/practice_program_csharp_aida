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
    }
}