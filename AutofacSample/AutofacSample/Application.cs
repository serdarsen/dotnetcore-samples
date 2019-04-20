using System.Linq;
using System.Reflection;

using Autofac;

namespace AutofacSample
{
    public class Application
    {
        public IContainer Container { get; }

        public Application()
        {
            Container = Configure();
        }

        public IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BookService>().As<IBookService>();

<<<<<<< HEAD
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(c => c.Namespace.Contains("Utilities"))
                   .As(c => c.GetInterfaces()
                             .FirstOrDefault(i => i.Name == "I" + c.Name))
                   .InstancePerDependency();
=======
            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(c => c.Namespace.Contains("Utilities"))
                   .As(c => c.GetInterfaces()
                   .Where(i => i.Namespace.Contains("Contracts"))
                   .FirstOrDefault(i => i.Name == "I" + c.Name));
>>>>>>> daae48c9b52fb89d0aee47e22df6c447bb3c5665

            return builder.Build();
        }
    }
}