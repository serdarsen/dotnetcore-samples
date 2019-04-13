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
        protected Mock<IBookRepository> MockIBookRepository { get; }
        protected Mock<ILogger> MockILogger { get; }

        public BaseTests()
        {
            Container = Configure();
            Scope = Container.BeginLifetimeScope();
            MockIBookService = new Mock<IBookService>();
            MockIBookRepository = new Mock<IBookRepository>();
            MockILogger = new Mock<ILogger>();
        }

        public IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BookService>().As<IBookService>();

            builder.Register(c => MockIBookRepository.Object).As<IBookRepository>();
            
            builder.Register(c => MockILogger.Object).As<ILogger>();

            return builder.Build();
        }
        
        public void Setup_BookRepository_GetById_Returns_Book10()
        {
            MockIBookRepository.Setup(x => x.GetById(It.IsAny<int>()))
                                .Returns(GetFakeBook10());
        }

        public void Verify_BookRepository_GetByIdInt()
        {
            MockIBookRepository.Verify(x => x.GetById(It.IsAny<int>()));
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