using System.Linq;
using System.Reflection;

using Autofac;

namespace AutofacSample
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            builder.RegisterType<BookService>().As<IBookService>();

            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(x => x.Namespace.Contains("Utilities"))
                   .As(x => x.GetInterfaces()
                             .FirstOrDefault(y => y.Name == "I" + x.Name));
            
            return builder.Build();
        }
    }
}