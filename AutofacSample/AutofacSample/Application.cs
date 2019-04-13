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
                .Where(x => x.Namespace.Contains("Utilities"))
                .As(x => x.GetInterfaces()
                    .FirstOrDefault(y => y.Name == "I" + x.Name));

            return builder.Build();
        }
    }
}