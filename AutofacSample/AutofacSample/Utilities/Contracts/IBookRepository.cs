using System.Collections.Generic;

namespace AutofacSample.Utilities.Contracts
{
    public interface IBookRepository
    {
        Dictionary<int, Book> GetAll();
        Book GetById(int id);
        void Save(Book book);
    }
}