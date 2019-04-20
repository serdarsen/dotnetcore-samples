using AutofacSample.Contracts;
using Moq;
using static AutofacSample.NUnitTests.FakeDataHelper;

namespace AutofacSample.NUnitTests
{
    public static class MockSetupHelper
    {
        public static void Setup_GetById_Returns_Book10(this Mock<IBookRepository> repository)
        {
            repository.Setup(x => x.GetById(It.IsAny<int>()))
                      .Returns(GetFakeBook10());
        }

        public static void Verify_GetById(this Mock<IBookRepository> repository)
        {
            repository.Verify(x => x.GetById(It.IsAny<int>()));
        }
    }
}