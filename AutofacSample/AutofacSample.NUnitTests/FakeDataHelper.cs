namespace AutofacSample.NUnitTests
{
    public static class FakeDataHelper
    {
        public static Book GetFakeBook10()
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