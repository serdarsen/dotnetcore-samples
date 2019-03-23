using System.Collections.Generic;
using InheritanceSample.Models;

namespace InheritanceSample.Contracts
{
    public interface ICSharpCourseService : IBaseCourseService
    {
        void UpdateUser();
        List<User> GetUserList();
    }
}