using Autofac;
using AutofacSample.Utilities;
using Moq;
using NUnit.Framework;

namespace AutofacSample.NUnitTests
{
    public class BaseTests
    {
        private IContainer Container { get; }
        protected ILifetimeScope Scope { get; }
        protected Mock<IBookService> MockIBookService { get; }
        protected Mock<IBookRepository> MockIBooksRepository { get; }
        protected Mock<ILogger> MockILogger { get; }

        public BaseTests()
        {
            Container = Configure();
            Scope = Container.BeginLifetimeScope();
            MockIBookService = new Mock<IBookService>();
            MockIBooksRepository = new Mock<IBookRepository>();
            MockILogger = new Mock<ILogger>();
        }

        public IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BookService>().As<IBookService>();

            builder.Register(c => MockIBooksRepository.Object).As<IBookRepository>();
            
            builder.Register(c => MockILogger.Object).As<ILogger>();

            return builder.Build();
        }

        public void SetupScenarioBookRepositoryGetByIdReturnsBook10()
        {
            MockIBooksRepository.Setup(x => x.GetById(It.IsAny<int>()))
                                .Returns(GetFakeBook10());
        }

        public void VerifyScenarioBookRepositoryGetByIdInt()
        {
            MockIBooksRepository.Verify(x => x.GetById(It.IsAny<int>()));
        }

        public Book GetFakeBook10()
        {
            var book = new Book()
            {
                Id = 10,
                Name = "Book 10",
                ISBN = "ISBN10"
            };

            return book;
        }
    }
}