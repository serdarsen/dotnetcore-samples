using System.Linq;
using System.Reflection;
using Autofac;

namespace AutofacSample
{
    public class Application
    {
        private IContainer Container { get; }
        public ILifetimeScope Scope { get; }

        public Application()
        {
            Container = Configure();
            Scope = Container.BeginLifetimeScope();
        }

        public IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BookService>().As<IBookService>();

            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(c => c.Namespace.Contains("Utilities"))
                .As(c => c.GetInterfaces()
                          .Where(i => i.Namespace.Contains("Contracts"))
                          .FirstOrDefault(i => i.Name == "I" + c.Name));

            return builder.Build();
        }
    }
}