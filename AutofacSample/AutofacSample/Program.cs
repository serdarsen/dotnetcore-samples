using System;
using System.Linq;
using System.Reflection;
using Autofac;

namespace AutofacSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var application = new Application();
            var bookService = application.Scope.Resolve<IBookService>();
            bookService.GetById(1);
        }
    }
}
