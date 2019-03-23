using InheritanceSample.Contracts;
using InheritanceSample.Factories;

namespace InheritanceSample.Services
{
    public class BaseCourseService<TIUserFactory> where TIUserFactory : IUserFactory
    {
        private readonly TIUserFactory _iUserFactory;

        public BaseCourseService(TIUserFactory iUserFactory)
        {
            _iUserFactory = iUserFactory;
        }

        public bool CreateUser()
        {
            return _iUserFactory.Create();
        }

        public bool DeleteUser()
        {
            return _iUserFactory.Delete();
        }
    }
}
