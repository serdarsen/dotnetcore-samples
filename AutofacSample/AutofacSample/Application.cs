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

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(c => c.Namespace.Contains("Utilities"))
                   .As(c => c.GetInterfaces()
                             .FirstOrDefault(i => i.Name == "I" + c.Name))
                   .InstancePerDependency();
            
            return builder.Build();
        }
    }
}