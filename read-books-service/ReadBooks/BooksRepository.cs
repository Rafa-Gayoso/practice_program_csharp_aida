using System;
using System.Collections.Generic;

namespace ReadBooks;

public interface BooksRepository
{
    List<Book> GetBooksReadBy(Guid userId);
}