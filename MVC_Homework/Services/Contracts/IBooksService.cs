using MVC_Homework.Models.DatabaseModels;

namespace MVC_Homework.Services.Contracts
{
    public interface IBooksService
    {
        List<Book> GetBooks();
        Book Get(int id);
        void Create(Book book);
        void Update(int id, Book book);
        void Delete(int id);
    }
}
