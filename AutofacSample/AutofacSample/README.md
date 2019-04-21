# Asp.Net Core Autofac Kullanımı

Inversion of Control prensibiyle geliştirmekte olduğumuz projeler büyüyüp, bağımlılıkları çoğaldıkça bunları sisteme teker teker enjekte etmek zaman alabiliyor. Bu işlemi kolay hale getiren kütüphaneler arasında Autofac, Asp.Net Core'un kendi Dependency Injection sistemine, kullanımı kolay ve özellikleri güçlü bir alternatif olarak karşımıza çıkıyor.

Autofac ile sınıf ve arayüzleri sisteme birer satırla kaydedebildiğimiz gibi, bunları Autofac'in where metoduyla belli koşullar altında tek seferde de ekleyebiliyoruz.

# AutofacSample
Bitmiş haline [bu bağlantıdan](https://www.github.com/serdarsen/dotnetcore-samples/tree/master/AutofacSample/AutofacSample)  ulaşabileceğiniz AutofacSample uygulamamızı yazmaya başlayalım.

Yeni bir Asp.Net Core console uygulaması oluşturup, Autofac paketini Nuget ile yükleyelim.

Örnek projemiz, id'si ile çağırdığımız kitabın ismini ekrana yazacak.

* Book.cs
* Program.cs
* Application.cs
* BookService.cs
* IBookService.cs
* Utilities
  * Logger.cs
  * BookRepository.cs
  * Contracts
    * ILogger.cs
    * IBookRepository.cs

Buradaki Program hariç, Application, BookService, IBookService, BookRepository, Logger, ILogger vs tüm sınıflar ve Utilities, Contracts klasörleri bizim isteğimizle, konuyu daha iyi anlamamız için oluşturup isimlendirdiğimiz yapılar.  

#### Book.cs
```csharp
public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```
#### IBookRepository.cs 
```csharp
public interface IBookRepository
{
    Book GetById(int id);
}
```
#### BookRepository.cs
```csharp
public class BookRepository : IBookRepository
{
    private readonly Dictionary<int, Book> _bookDictionary;

    public BookRepository()
    {
        _bookDictionary = new Dictionary<int, Book>();
        _bookDictionary.Add(1, new Book { Id = 1, Name = "Test Book 1" });
        _bookDictionary.Add(2, new Book { Id = 2, Name = "Test Book 2" });
        _bookDictionary.Add(3, new Book { Id = 3, Name = "Test Book 3" });
    }
   
    public Book GetById(int id)
    {
        var book = _bookDictionary[id];

        return book;
    }
}
```
#### ILogger.cs
```csharp
public interface ILogger
{
    void Log(string message);
}
```
#### Logger.cs
```csharp
public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
```
#### IBookService.cs 
```csharp
public interface IBookService
{
    Book GetById(int id);
}
```

BookService'in BookRepository ve Logger'a bağımlılığı var ve bunları Aplication içinde sisteme enjekte edeceğiz.
#### BookService.cs
```csharp
public class BookService : IBookService
{
    private readonly IBookRepository _iBookRepository;
    private readonly ILogger _iLogger;

    public BookService(IBookRepository iBookRepository,
                       ILogger iLogger)
    {
        _iBookRepository = iBookRepository;
        _iLogger = iLogger;
    }

    public Book GetById(int id)
    {
        this._iLogger.Log("Getting Book " + id);
        
        var book = _iBookRepository.GetById(id);

        return book;
    }
}
```
Burada Autofac'in ContainerBuilder ve Container sınıflarını kullanıyoruz. ContainerBuilder'ın RegisterType<> ve As<> metodlarıyla BookService'i IBookService olarak kaydediyoruz. 

BookRepository ve Logger'ı aynı namespace'e koyduğumuz için onları RegisterAssemblyTypes metoduyla enjekte edebiliyoruz. 

Assembly.GetExecutingAssembly() ile, çalıştırdığımız modülü adres gösteriyoruz.

>Where metodu ile namespace'inde Utilities geçen sınıfların "I" + sınıfın kendi ismi şeklinde isimlendirilmiş arayüzlerini bulup enjekte ediyoruz.

InstancePerDependency, enjekte edilen sınıfın yaşam döngüsünü belirliyor ve Asp.Net Core'un transient yapısına eşdeğer olarak bağımlılık her çağırıldığında sınıfı yeniden oluştur anlamı taşıyor. Bunun yerine Asp.Net Core'un singleton yapısına eşdeğer olarak bağımlılık için bir tek nesne üretip her çağırıldığında onu getiren SingleInstance metodunu da çağırabilirdik. Daha fazla bilgi için [şu sayfayı](https://autofaccn.readthedocs.io/en/latest/)  okuyabilirsiniz. 

#### Application.cs
```csharp
public class Application
{
    public IContainer Container { get; }

    public Application()
    {
        Container = Configure();
    }

    public IContainer Configure()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<BookService>().As<IBookService>();

        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(c => c.Namespace.Contains("Utilities"))
               .As(c => c.GetInterfaces()
                         .FirstOrDefault(i => i.Name == "I" + c.Name));
               .InstancePerDependency();

        return builder.Build();
    }
}
```
Kitabımızı görüntüleyebilmek için yeni bir application nesnesi üretiyoruz. Container'in Resolve metodu ile enjekte ettiğimiz BookService'ı alıyoruz. Resolve işlemi BookService'in bağımlılıklarını da üretip ona verdi. Artık normal bir şekilde bookService'in GetById metodunu çağırabiliriz.  

#### Program.cs
```csharp
class Program
{
    static void Main(string[] args)
    {
        var application = new Application();
        var bookService = application.Container.Resolve<IBookService>();
        bookService.GetById(1);
    }
}
```

Programımızı çalıştıralım.

#### Console output
```sh
Getting Book 1
```

# Kaynaklar
* [Autofac’s documentation](https://autofaccn.readthedocs.io/en/latest/)
* [Medium - Asp.Net Core Autofac kullanımı](https://medium.com/@serdarsendev/asp-net-core-autofac-kullan%C4%B1m%C4%B1-ffec57b02f93)