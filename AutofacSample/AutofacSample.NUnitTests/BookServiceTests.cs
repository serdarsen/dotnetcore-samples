using Autofac;
using AutofacSample.Utilities;
using NUnit.Framework;
using Shouldly;
using static AutofacSample.NUnitTests.FakeDataHelper;

namespace AutofacSample.NUnitTests
{
    public class BookServiceTests : BaseTests 
    {
        public IBookService SystemUnderTest { get; set; }

        [SetUp]
        public void run_before_every_test()
        {
            SystemUnderTest = Container.Resolve<IBookService>();
        }

        [Test]
        public void BookService_GetById()
        {
            // arrange
            var book10 = GetFakeBook10();
            MockIBookRepository.Setup_GetById_Returns_Book10();

            // act
            var result = SystemUnderTest.GetById(1);
            
            // assert
            result.Name.ShouldBe(book10.Name);
            MockIBookRepository.Verify_GetById();
        }
    }
}