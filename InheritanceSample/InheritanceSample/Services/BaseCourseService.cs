using InheritanceSample.Contracts;

namespace InheritanceSample.Services
{
    public class BaseCourseService<TIBaseUserFactory, TIBaseUserRepository> 
                                   where TIBaseUserFactory : IBaseUserFactory
                                   where TIBaseUserRepository : IBaseUserRepository
                                                                    
    {
        private readonly TIBaseUserFactory _iBaseUserFactory;
        private readonly TIBaseUserRepository _iBaseUserRepository;

        public BaseCourseService(TIBaseUserFactory iBaseUserFactory, TIBaseUserRepository iBaseUserRepository)
        {
            _iBaseUserFactory = iBaseUserFactory;
            _iBaseUserRepository = iBaseUserRepository;
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
