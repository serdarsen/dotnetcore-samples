using InheritanceSample.Services;

namespace InheritanceSample.Contracts
{
    public interface ICSharpCourseService : IBaseCourseService
    {
        void UpdateUser();
    }
}