using System.Collections.Generic;
using InheritanceSample.Contracts;
using InheritanceSample.Models;

namespace InheritanceSample.Repositories
{
    public class JavaUserRepository : BaseUserRepository, IJavaUserRepository
    {
        public List<User> GetAll()
        {
            List<User> userList = new List<User>();
            
            userList.Add(new User { ID = 1, Name = "Test Java User 1" });
            userList.Add(new User { ID = 2, Name = "Test Java User 2" });
            userList.Add(new User { ID = 3, Name = "Test Java User 3" });

            return userList;
        }
    }
}