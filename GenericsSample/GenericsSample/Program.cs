using System;

namespace GenericsSample
{
    public class Program
    {
        static void Main(string[] args)
        {

            // MyGenericClass with int
            MyGenericClass<int> intGenericClass = new MyGenericClass<int>(10);
            int intVal = intGenericClass.GenericMethod(200);

            // MyGenericBookClass with TutorialBook
            var tutBook = new TutorialBook("Blue");
            MyGenericBookClass<TutorialBook> tutorialBookClass = new MyGenericBookClass<TutorialBook>();
            TutorialBook tutorialBook = tutorialBookClass.GenericMethod(tutBook);

            Console.WriteLine(tutorialBook.Name);

            Console.ReadLine();
        }
    }

    public class MyGenericClass<T>
    {
        private T genericMemberVariable;
        public T GenericProperty { get; set; }

        public MyGenericClass(T value)
        {
            genericMemberVariable = value;
        }

        public T GenericMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T), genericParameter);
            Console.WriteLine("Return type: {0}, value: {1}", typeof(T), genericMemberVariable);

            return genericMemberVariable;
        }
    }

    public class MyGenericBookClass<TIBook> where TIBook : IBook,  new()
    {
        public TIBook GenericMethod(TIBook book)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(TIBook), book);
            Console.WriteLine("Return type: {0}, value: {1}", typeof(TIBook), book);

            book = new TIBook();
            Console.WriteLine(book.GetBookName());

            return book;
        }
    }

    public interface IBook
    {
        string Name { get; set; }
        string GetBookName();
    }

    public class TutorialBook : IBook
    {
        public string PageNum { get; set; }

        public TutorialBook(string name)
        {
        }

        public TutorialBook()
        {
        }

        public string Name { get; set; }
        public string GetBookName()
        {
            return "Red";
        }
    }
}
