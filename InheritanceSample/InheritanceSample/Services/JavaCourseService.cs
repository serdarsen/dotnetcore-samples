using InheritanceSample.Contracts;

namespace InheritanceSample.Services
{
    public class JavaCourseService : BaseCourseService<IJavaUserFactory>, IJavaCourseService
    {
        private readonly IJavaUserFactory _iJavaUserFactory;

        public JavaCourseService(IJavaUserFactory iJavaUserFactory) : base(iJavaUserFactory)
        {
            _iJavaUserFactory = iJavaUserFactory;
        }

        public void UpgradeUser()
        {
            _iJavaUserFactory.Upgrade();
        }
    }
}