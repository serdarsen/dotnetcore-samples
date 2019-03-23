using InheritanceSample.Factories;

namespace InheritanceSample.Services
{
    public class Course<TIUserFactory> where TIUserFactory : IUserFactory
    {
        private readonly TIUserFactory _iUserFactory;

        public Course(TIUserFactory iUserFactory)
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
