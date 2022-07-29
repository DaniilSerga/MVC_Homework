using Microsoft.EntityFrameworkCore;
using MVC_Homework.Models;
using MVC_Homework.Models.DatabaseModels;
using MVC_Homework.Services.Contracts;

namespace MVC_Homework.Services.Implementations
{
    public class BooksService : IBooksService
    {
        private readonly ApplicationContext _context;

        public BooksService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Book> GetBooks() => _context.Books.AsNoTracking().ToList();

        public Book Get(int id)
        {
            var book = _context.Books.FirstOrDefault(u => u.Id == id);

            if (book is null)
            {
                throw new ArgumentException("User with current Id was not found.", nameof(id));
            }

            return book;
        }

        public void Create(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book), "Book was null");
            }

            _context.Books.Add(book);

            _context.SaveChanges();
        }

        public void Update(int id, Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book), "Current book is null.");
            }
            var dbBook = _context.Books.FirstOrDefault(u => u.Id == id);

            if (dbBook is null)
            {
                throw new ArgumentException("Book with current Id was not found.");
            }

            dbBook = book;

            _context.Books.Update(dbBook);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(u => u.Id == id);

            if (book is null)
            {
                throw new ArgumentException("Book with current Id was not found.");
            }

            _context.Books.Remove(book);

            _context.SaveChanges();
        }
    }
}
