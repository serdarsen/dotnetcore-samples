using InheritanceSample.Services;

namespace InheritanceSample.Contracts
{
    public interface ICSharpCourseService : ICourseService
    {
        void UpdateUser();
    }
}