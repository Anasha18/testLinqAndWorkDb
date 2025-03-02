using System.Reflection.Metadata;
using testLinq.Connection;
using testLinq.Model;

namespace testLinq;

public class LogicDb
{
    private Barkovskii2323dLearningDbContext _db;

    public LogicDb(Barkovskii2323dLearningDbContext db)
    {
        _db = db;
    }
    
    public void AddNewBook()
    {
        Console.Write("Введите название книги: ");
        string title = Console.ReadLine();

        Console.WriteLine();
        ViewAuthors();
        
        Console.Write("Выберите автора из списка для книги: ");
        int author_id = int.Parse(Console.ReadLine());
        
        var author = _db.Authors
            .FirstOrDefault(item => item.AuthorId == author_id);

        if (author == null)
        {
            Console.WriteLine("Автор с таким ID не найден.");
            return;
        }

        Console.Write("Введите год написания книги: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Введите жанр книги: ");
        string genre = Console.ReadLine();

        Console.Write("Введите кол-во страниц в книге: ");
        int pages = int.Parse(Console.ReadLine());
        
        Book newBook = new Book
        {
            Title = title,
            AuthorId = author_id,
            Year = year,
            Genre = genre,
            Pages = pages
        };

        _db.Books.Add(newBook);
        _db.SaveChanges();
        Console.WriteLine("Книга успешно добавлена");
    }

    public void ViewAuthors()
    {
        var authors = _db.Authors.ToList();

        authors.ForEach(item =>
            Console.WriteLine(
                $"Айди автора: {item.AuthorId} \tИмя: {item.Name} \tСтрана: {item.Country} \tДень рождения: {item.BirthYear}"));
    }

    public void ViewBooks()
    {
        var books = _db.Books.Join
            (_db.Authors,
                book => book.AuthorId,
                author => author.AuthorId,
                (book, author) =>
                    new { Book = book, Author = author })
            .Select(
                item => new
                {
                    item.Book.BookId,
                    item.Book.Title,
                    item.Book.AuthorId, item.Book.Year,
                    item.Book.Genre,
                    item.Book.Pages
                }).ToList();

        books.ForEach(book =>
            Console.WriteLine(
                $"Айди книги: {book.BookId} \tНазвание: {book.Title} \tГод написания: {book.Year} \tЖанр: {book.Genre} \tКол-во страниц: {book.Pages}"));
    }

    public void DeleteBook()
    {
        ViewBooks();
        Console.WriteLine();

        Console.Write("Введите id книги для ее удаления: ");
        int bookId = int.Parse(Console.ReadLine());

        var book = _db.Books
            .FirstOrDefault(item => item.BookId == bookId);

        if (bookId == null)
        {
            Console.WriteLine("Такого id не нет! ССОРИ");
            return;
        }

        _db.Books.Remove(book);
        _db.SaveChanges();
        Console.WriteLine("Книга успешна удалена!!!");
    }

    public void UpdateBook()
    {
        ViewBooks();
        Console.WriteLine();
        
        Console.Write("Введите id книги для ее обновления: ");
        int bookId = int.Parse(Console.ReadLine());

        var book = _db.Books
            .FirstOrDefault(item => item.BookId == bookId);
        
        if (book == null)
        {
            Console.WriteLine("Такого id не нет! ССОРИ");
            return;
        }

        Console.Write("Ввдеите новое название для книги: ");
        string title = Console.ReadLine();

        book.Title = title;
        _db.SaveChanges();
        Console.WriteLine("Назавние книги успешно обновлено!");
    }
    
}