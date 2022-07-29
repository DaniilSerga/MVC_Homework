using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Homework.Models.DatabaseModels
{
    [Table("Authors")]
    public class Author
    {
        public Author() { }

        public int Id { get; set; }

        public string Name { get; set; } = "";

        public List<Book> Books { get; set; } = new();
    }
}
