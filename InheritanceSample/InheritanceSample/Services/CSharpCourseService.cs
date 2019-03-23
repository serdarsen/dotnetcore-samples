using System.Collections.Generic;
using InheritanceSample.Contracts;
using InheritanceSample.Models;

namespace InheritanceSample.Services
{
    public class CSharpCourseService : BaseCourseService<ICSharpUserFactory, ICSharpUserRepository> , ICSharpCourseService
    {
        private readonly ICSharpUserFactory _iCSharpUserFactory;
        private readonly ICSharpUserRepository _iCSharpUserRepository;

        public CSharpCourseService(ICSharpUserFactory iCSharpUserFactory,
                                   ICSharpUserRepository iCSharpUserRepository) : base(iCSharpUserFactory, iCSharpUserRepository)
        {
            _iCSharpUserFactory = iCSharpUserFactory;
            _iCSharpUserRepository = iCSharpUserRepository;
        }

        public void UpdateUser()
        {
            _iCSharpUserFactory.Update();
        }

        public List<User> GetUserList()
        {
            var userList = _iCSharpUserRepository.GetAll();

            return userList;
        }
    }
}