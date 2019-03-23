using InheritanceSample.Factories;

namespace InheritanceSample.Services
{
    public class JavaCourse : Course<IJavaUserFactory>, IJavaCourse
    {
        private readonly IJavaUserFactory _iJavaUserFactory;

        public JavaCourse(IJavaUserFactory iJavaUserFactory) : base(iJavaUserFactory)
        {
            _iJavaUserFactory = iJavaUserFactory;
        }

        public void UpgradeUser()
        {
            _iJavaUserFactory.Upgrade();
        }
    }
}