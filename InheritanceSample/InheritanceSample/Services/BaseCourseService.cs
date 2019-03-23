using InheritanceSample.Contracts;
using InheritanceSample.Factories;

namespace InheritanceSample.Services
{
    public class BaseCourseService<TIUserFactory> where TIUserFactory : IBaseUserFactory
    {
        private readonly TIUserFactory _iBaseUserFactory;

        public BaseCourseService(TIUserFactory iBaseUserFactory)
        {
            _iBaseUserFactory = iBaseUserFactory;
        }

        public bool CreateUser()
        {
            return _iBaseUserFactory.Create();
        }

        public bool DeleteUser()
        {
            return _iBaseUserFactory.Delete();
        }
    }
}
