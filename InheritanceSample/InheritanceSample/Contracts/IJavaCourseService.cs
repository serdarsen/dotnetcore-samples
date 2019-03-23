namespace InheritanceSample.Services
{
    public interface IJavaCourseService : IBaseCourseService
    {
        void UpgradeUser();
    }
}