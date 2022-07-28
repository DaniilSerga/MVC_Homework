using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Homework.Models.DatabaseModels
{
    [Table("Bookshelves")]
    public class Bookshelf
    {
        [Key]
        public int Id { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}
