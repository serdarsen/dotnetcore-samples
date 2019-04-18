using Autofac;
using AutofacSample.Contracts;
using AutofacSample.Utilities;
using Moq;
using NUnit.Framework;

namespace AutofacSample.NUnitTests
{
    public abstract class BaseTests
    {
        protected IContainer Container { get; }
        protected Mock<IBookService> MockIBookService { get; }
        protected Mock<IBookRepository> MockIBookRepository { get; }
        protected Mock<ILogger> MockILogger { get; }

        protected BaseTests()
        {
            MockIBookService = new Mock<IBookService>();
            MockIBookRepository = new Mock<IBookRepository>();
            MockILogger = new Mock<ILogger>();
            Container = Configure();
        }

        public IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => MockIBookRepository.Object).As<IBookRepository>().InstancePerDependency();

            builder.Register(c => MockILogger.Object).As<ILogger>().InstancePerDependency();

            builder.RegisterType<BookService>().As<IBookService>().InstancePerDependency();

            return builder.Build();
        }
    }
}