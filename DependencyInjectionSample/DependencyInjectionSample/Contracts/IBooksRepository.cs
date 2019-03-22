using System.Collections.Generic;

using DependencyInjectionSample.Models;

namespace DependencyInjectionSample.Contracts
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
    }
}
