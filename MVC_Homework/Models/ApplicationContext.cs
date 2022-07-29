using Microsoft.EntityFrameworkCore;
using MVC_Homework.Models.DatabaseModels;

namespace MVC_Homework.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
    }
}
