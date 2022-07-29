using MVC_Homework.Models.DatabaseModels;

namespace MVC_Homework.Services.Contracts
{
    public interface IAuthorsService
    {
        List<Author> GetAuthors();
        Author Get(int id);
        void Create(Author author);
        void Update(int id, Author author);
        void Delete(int id);
    }
}
