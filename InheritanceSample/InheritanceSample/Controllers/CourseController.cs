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

        //[HttpGet]
        //public IActionResult List()
        //{
        //    var model = _booksRepository.GetAll();

        //    return View(model);
        //}
    }
}