using Autofac;
using AutofacSample.Utilities;
using NUnit.Framework;
using Shouldly;

namespace AutofacSample.NUnitTests
{
    public class BookServiceTests : BaseTests 
    {
        public IBookService SystemUnderTest { get; set; }

        [SetUp]
        public void run_before_every_test()
        {
            SystemUnderTest = Scope.Resolve<IBookService>();
        }

        [Test]
        public void BookService_GetById()
        {
            // arrange
            Setup_BookRepository_GetById_Returns_Book10();

            // act
            var result = SystemUnderTest.GetById(1);
            
            // assert
            result.Name.ShouldBe("Book 10");
            Verify_BookRepository_GetByIdInt();
        }
    }
}