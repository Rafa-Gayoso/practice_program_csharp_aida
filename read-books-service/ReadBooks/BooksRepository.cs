using System;
using System.Collections.Generic;

namespace ReadBooks;

public interface BooksRepository
{
    IEnumerable<User> GetFriendsOf(Guid requestUserId);
}