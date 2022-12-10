using Proiect_.net.Models;
using Microsoft.EntityFrameworkCore;

namespace Proiect_.net.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> UsersTable { get; set; }
        public DbSet<Book> BooksTable { get; set; }
        public DbSet<Author> AuthorsTable { get; set; }
        public DbSet<Category> CategoriesTable { get; set; }
        public DbSet<Belongs> BelongsTable { get; set; }
        public DbSet<Borrows> BorrowsTable { get; set; }
        public DbSet<Writes> WritesTable { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
