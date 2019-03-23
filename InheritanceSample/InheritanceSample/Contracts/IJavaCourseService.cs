namespace InheritanceSample.Services
{
    public interface IJavaCourseService : ICourseService
    {
        void UpgradeUser();
    }
}