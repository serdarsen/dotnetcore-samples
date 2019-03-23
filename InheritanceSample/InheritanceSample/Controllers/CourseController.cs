using InheritanceSample.Contracts;
using InheritanceSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace InheritanceSample.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICSharpCourseService _iCSharpCourseService;
        private readonly IJavaCourseService _iJavaCourseService;

        public CourseController(ICSharpCourseService iCSharpCourseService,
                                IJavaCourseService iJavaCourseService)
        {
            _iCSharpCourseService = iCSharpCourseService;
            _iJavaCourseService = iJavaCourseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void JavaCourseExample()
        {
            _iJavaCourseService.CreateUser();
            _iJavaCourseService.UpgradeUser();
            _iJavaCourseService.DeleteUser();
            _iJavaCourseService.GetUserList();
        }

        [HttpPost]
        public void CSharpCourseExample()
        {
            _iCSharpCourseService.CreateUser();
            _iCSharpCourseService.UpdateUser();
            _iCSharpCourseService.DeleteUser();
            _iCSharpCourseService.GetUserList();
        }
    }
}