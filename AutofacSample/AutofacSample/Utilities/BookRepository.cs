using System.Collections.Generic;

using AutofacSample.Utilities.Contracts;

namespace AutofacSample.Utilities
{
    public class BookRepository : IBookRepository
    {
        private readonly Dictionary<int, Book> _bookDictionary;

        public BookRepository()
        {
            _bookDictionary =
                new Dictionary<int, Book>();
            _bookDictionary.Add(1, new Book { Id = 1, ISBN = "Test ISBN 1", Name = "Test Book 1" });
            _bookDictionary.Add(2, new Book { Id = 2, ISBN = "Test ISBN 2", Name = "Test Book 2" });
            _bookDictionary.Add(3, new Book { Id = 3, ISBN = "Test ISBN 3", Name = "Test Book 3" });
        }

        public Dictionary<int, Book> GetAll()
        {
            return _bookDictionary;
        }

        public Book GetById(int id)
        {
            var book = _bookDictionary[id];

            return book;
        }

        public void Save(Book book)
        {
            _bookDictionary.Add(book.Id, book);
        }
    }
}