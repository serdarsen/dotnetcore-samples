using System.Collections.Generic;

using InheritanceSample.Models;

namespace InheritanceSample.Repositories
{
    public class InMemoryBooksRepository : IBooksRepository
    {
        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();

            books.Add(new Book { ID = 1, ISBN = "Test ISBN 1", Name = "Test Book 1" });
            books.Add(new Book { ID = 2, ISBN = "Test ISBN 2", Name = "Test Book 2" });
            books.Add(new Book { ID = 3, ISBN = "Test ISBN 3", Name = "Test Book 3" });

            return books;
        }
    }
}
