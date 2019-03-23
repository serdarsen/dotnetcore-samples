using InheritanceSample.Factories;

namespace InheritanceSample.Services
{
    public class CSharpCourse : Course<ICSharpUserFactory> , ICSharpCourse
    {
        private readonly ICSharpUserFactory _iCSharpUserFactory;

        public CSharpCourse(ICSharpUserFactory iCSharpUserFactory) : base(iCSharpUserFactory)
        {
            _iCSharpUserFactory = iCSharpUserFactory;
        }

        public void UpdateUser()
        {
            _iCSharpUserFactory.Update();
        }
    }
}