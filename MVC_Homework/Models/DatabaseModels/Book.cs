using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Homework.Models.DatabaseModels
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int AuthorId { get; set; }

        public int BookshelfId { get; set; }

        public Author Author { get; set; } = new();

        public Bookshelf Bookshelf { get; set; } = new();
    }
}
