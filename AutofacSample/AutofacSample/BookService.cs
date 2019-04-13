using AutofacSample.Contracts;
using AutofacSample.Utilities;

namespace AutofacSample
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _iBookRepository;
        private readonly ILogger _iLogger;

        public BookService(IBookRepository iBookRepository,
                           ILogger iLogger)
        {
            _iBookRepository = iBookRepository;
            _iLogger = iLogger;
        }

        public Book GetById(int id)
        {
            this._iLogger.Log("Getting Book " + id);
            
            // Retrieve from db.
            var book = _iBookRepository.GetById(id);

            return book;
        }

        public void Save(Book book)
        {
            this._iLogger.Log("Saving book " + book.Id);
            // Save to db.

            _iBookRepository.Save(book);
        }
    }
}