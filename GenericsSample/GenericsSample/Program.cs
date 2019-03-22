using System;

namespace GenericsSample
{
    public class Program
    {
        static void Main(string[] args)
        {
            //    var book = new Book {Isbn = "1111", Title = "C# Advanced"};

            //    var numbers = new GenericList<int>();
            //    numbers.Add(10);

            //    var books = new GenericList<Book>();
            //    books.Add(book);

            //    var dictionary = new GenericDictionary<string, Book>();
            //    dictionary.Add("1234", new Book());

            // var number = new Nullable<int>(5);
            var number = new Nullable<int>();
            Console.WriteLine("Has Value ?" + number.HasValue);
            Console.WriteLine("Value: " + number.GetValueOrDefault());
        }
    }
}
