using System.Collections.Generic;

using InheritanceSample.Models;

namespace InheritanceSample.Repositories
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
    }
}
