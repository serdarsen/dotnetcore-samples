namespace AutofacSample
{
    public class Application : IApplication
    {
        private readonly IBookService _iBookService;

        public Application(IBookService iBookService)
        {
            _iBookService = iBookService;
        }

        public void Run()
        {
            _iBookService.GetById(1);    
        }
    }
}