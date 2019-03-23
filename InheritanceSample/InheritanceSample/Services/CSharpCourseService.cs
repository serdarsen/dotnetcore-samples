using InheritanceSample.Contracts;
using InheritanceSample.Factories;

namespace InheritanceSample.Services
{
    public class CSharpCourseService : BaseCourseService<ICSharpUserFactory> , ICSharpCourseService
    {
        private readonly ICSharpUserFactory _iCSharpUserFactory;

        public CSharpCourseService(ICSharpUserFactory iCSharpUserFactory) : base(iCSharpUserFactory)
        {
            _iCSharpUserFactory = iCSharpUserFactory;
        }

        public void UpdateUser()
        {
            _iCSharpUserFactory.Update();
        }
    }
}