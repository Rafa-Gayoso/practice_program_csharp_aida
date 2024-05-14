using System;
using System.Collections.Generic;

namespace ReadBooks;

public interface DataPersistence
{
    IEnumerable<User> GetFriendsOf(Guid requestUserId);
}