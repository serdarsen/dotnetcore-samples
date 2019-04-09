namespace SimpleInjectorSample
{
    public interface IBookService
    {
        Book GetById(int id);
        void Save(Book book);
    }
}