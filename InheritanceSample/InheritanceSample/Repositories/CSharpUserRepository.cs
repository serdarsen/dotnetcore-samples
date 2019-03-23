using System.Collections.Generic;
using InheritanceSample.Contracts;
using InheritanceSample.Models;

namespace InheritanceSample.Repositories
{
    public class CSharpUserRepository : BaseUserRepository, ICSharpUserRepository
    {
        public List<User> GetAll()
        {
            List<User> userList = new List<User>();

            userList.Add(new User { ID = 1, Name = "Test CSharp User 1" });
            userList.Add(new User { ID = 2, Name = "Test CSharp User 2" });
            userList.Add(new User { ID = 3, Name = "Test CSharp User 3" });

            return userList;
        }
    }
}