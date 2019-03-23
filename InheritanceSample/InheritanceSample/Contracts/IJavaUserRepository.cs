using System.Collections.Generic;
using InheritanceSample.Models;

namespace InheritanceSample.Contracts
{
    public interface IJavaUserRepository : IBaseUserRepository
    {
        List<User> GetAll();
    }
}