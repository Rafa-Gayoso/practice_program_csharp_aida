using System;
using System.Collections.Generic;

namespace ReadBooks;

public interface FriendsRepository
{
    IEnumerable<User> GetFriendsOf(Guid userId);
}