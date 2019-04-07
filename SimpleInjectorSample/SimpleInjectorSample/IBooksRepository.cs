using System;
using System.Collections.Generic;

namespace SimpleInjectorSample
{
    public interface IBooksRepository
    {
        Dictionary<int, Book> GetAll();
        Book GetById(int id);
        void Save(Book book);
    }
}