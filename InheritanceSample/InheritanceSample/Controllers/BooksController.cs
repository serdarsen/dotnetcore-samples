using InheritanceSample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InheritanceSample.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var model = _booksRepository.GetAll();

            return View(model);
        }
    }
}