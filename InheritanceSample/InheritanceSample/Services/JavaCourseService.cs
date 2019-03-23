using System.Collections.Generic;
using InheritanceSample.Contracts;
using InheritanceSample.Models;

namespace InheritanceSample.Services
{
    public class JavaCourseService : BaseCourseService<IJavaUserFactory, IJavaUserRepository>, IJavaCourseService
    {
        private readonly IJavaUserFactory _iJavaUserFactory;
        private readonly IJavaUserRepository _iJavaUserRepository;

        public JavaCourseService(IJavaUserFactory iJavaUserFactory, 
                                 IJavaUserRepository iJavaUserRepository) : base(iJavaUserFactory, iJavaUserRepository)
        {
            _iJavaUserFactory = iJavaUserFactory;
            _iJavaUserRepository = iJavaUserRepository;
        }

        public void UpgradeUser()
        {
            _iJavaUserFactory.Upgrade();
        }

        public List<User> GetUserList()
        {
            var userList = _iJavaUserRepository.GetAll();

            return userList;
        }
    }
}