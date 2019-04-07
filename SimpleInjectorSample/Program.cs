using System;
using SimpleInjector;

namespace SimpleInjectorSample
{
    public class Program
    {
        public static readonly Container container;

        static Program()
        {
            // 1. Create a new Simple Injector container
            container = new Container();

            // 2. Configure the container (register)
            container.Register<IBooksRepository, BooksRepository>();
            container.Register<ILogger, Logger>();
            container.Register<BookService>();
            
            // 3. Verify your configuration
            container.Verify();
        }

        public static void Main(string[] args)
        {
            var bookService = container.GetInstance<BookService>();

            var book = bookService.GetById(1);

            Console.WriteLine(book.Name);
        }
    }
}
