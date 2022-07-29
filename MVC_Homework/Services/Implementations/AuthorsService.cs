using Microsoft.EntityFrameworkCore;
using MVC_Homework.Models;
using MVC_Homework.Models.DatabaseModels;
using MVC_Homework.Services.Contracts;

namespace MVC_Homework.Services.Implementations
{
    public class AuthorsService : IAuthorsService
    {
        private readonly ApplicationContext _context;

        public AuthorsService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Author> GetAuthors() => _context.Authors.AsNoTracking().ToList();

        public Author Get(int id)
        {
            var author = _context.Authors.FirstOrDefault(c => c.Id == id);

            if (author is null)
            {
                throw new Exception("Author was not found");
            }

            return author;
        }

        public void Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Authors.FirstOrDefault(u => u.Id == id);

            if (author is null)
            {
                throw new Exception("Author was not found.");
            }

            _context.Authors.Remove(author);
        }

        public void Update(int id, Author author)
        {
            if (author is null)
            {
                throw new ArgumentNullException(nameof(author), "The author passed as a parameter was empty.");
            }

            var dbAuthor = _context.Authors.FirstOrDefault(u => u.Id == id);

            if (dbAuthor is null)
            {
                throw new Exception("Author with current id does not exist.");
            }

            dbAuthor = author;

            _context.Authors.Update(dbAuthor);

            _context.SaveChanges();
        }
        
    }
}
