using System.Collections.Generic;
using InheritanceSample.Models;

namespace InheritanceSample.Contracts
{
    public interface IBaseCourseService
    {
        bool CreateUser();
        bool DeleteUser();
    }
}