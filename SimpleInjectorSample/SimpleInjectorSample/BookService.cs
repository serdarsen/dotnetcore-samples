using System;

namespace SimpleInjectorSample
{
    public class BookService
    {
        private readonly IBooksRepository _iBooksRepository;
        private readonly ILogger _iLogger;

        public BookService(IBooksRepository iBooksRepository,
                           ILogger iLogger)
        {
            _iBooksRepository = iBooksRepository;
            _iLogger = iLogger;
        }

        public Book GetById(int id)
        {
            this._iLogger.Log("Getting Book " + id);
            
            // Retrieve from db.
            var book = _iBooksRepository.GetById(id);

            return book;
        }

        public void Save(Book book)
        {
            this._iLogger.Log("Saving book " + book.Id);
            // Save to db.

            _iBooksRepository.Save(book);
        }
    }
}