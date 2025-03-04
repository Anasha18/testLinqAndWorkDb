using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using testLinq.Connection;
using testLinq.Model;

namespace testLinq;

public class OneToManyLogicDb
{
    private Barkovskii2323dLearningDbContext _db;

    public OneToManyLogicDb(Barkovskii2323dLearningDbContext db)
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
        var books = _db.Books
            .Include(item => item.Author)
            .Select(
                item => new
                {
                    item.BookId,
                    item.Author.Name,
                    item.Title,
                    item.Year,
                    item.Genre,
                    item.Pages
                }).ToList();

        books.ForEach(book =>
            Console.WriteLine(
                $"Айди книги: {book.BookId}| Автор: {book.Name}| Название: {book.Title}| Год написания: {book.Year}| Жанр: {book.Genre}| Кол-во страниц: {book.Pages}"));
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

    public void DeleteAuthor()
    {
        ViewAuthors();
        Console.Write("Выберите id автора для удаления: ");
        int authorId = int.Parse(Console.ReadLine());

        var author = _db.Authors.FirstOrDefault(item => item.AuthorId == authorId);

        if (author == null)
        {
            Console.WriteLine("Такого автора нет СОРРИ!");
            return;
        }

        var book = _db.Books.FirstOrDefault(item => item.AuthorId == authorId);

        _db.Books.Remove(book);
        _db.Authors.Remove(author);
        _db.SaveChanges();

        Console.WriteLine("Автор успешно удален!");
    }
}