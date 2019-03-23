using InheritanceSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace InheritanceSample.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICSharpCourse _iCSharpCourse;
        private readonly IJavaCourse _iJavaCourse;

        public CourseController(ICSharpCourse iCSharpCourse,
                                IJavaCourse iJavaCourse)
        {
            _iCSharpCourse = iCSharpCourse;
            _iJavaCourse = iJavaCourse;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void JavaCourseExample()
        {
            _iJavaCourse.CreateUser();
            _iJavaCourse.UpgradeUser();
            _iJavaCourse.DeleteUser();
        }

        //[HttpGet]
        //public IActionResult List()
        //{
        //    var model = _booksRepository.GetAll();

        //    return View(model);
        //}
    }
}