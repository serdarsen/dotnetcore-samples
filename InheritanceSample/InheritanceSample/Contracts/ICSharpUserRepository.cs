using System.Collections.Generic;
using InheritanceSample.Models;

namespace InheritanceSample.Contracts
{
    public interface ICSharpUserRepository : IBaseUserRepository
    {
        List<User> GetAll();
    }
}