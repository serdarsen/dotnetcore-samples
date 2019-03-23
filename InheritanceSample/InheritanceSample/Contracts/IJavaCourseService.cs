using System.Collections.Generic;
using InheritanceSample.Contracts;
using InheritanceSample.Models;

namespace InheritanceSample.Services
{
    public interface IJavaCourseService : IBaseCourseService
    {
        void UpgradeUser();
        List<User> GetUserList();
    }
}