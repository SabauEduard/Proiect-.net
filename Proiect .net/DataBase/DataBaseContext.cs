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

            modelBuilder.Entity<Writes>()
                .HasKey(w => new { w.BookId, w.AuthorId });

            modelBuilder.Entity<Writes>()
                .HasOne(w => w.Author)
                .WithMany(a => a.Writes)
                .HasForeignKey(w => w.AuthorId);

            modelBuilder.Entity<Writes>()
                .HasOne(w => w.Book)
                .WithMany(b => b.Writes)
                .HasForeignKey(w => w.BookId);


            modelBuilder.Entity<Belongs>()
                .HasKey(bl => new { bl.BookId, bl.CategoryId });

            modelBuilder.Entity<Belongs>()
                .HasOne(bl => bl.Book)
                .WithMany(b => b.Belongs)
                .HasForeignKey(bl => bl.BookId);

            modelBuilder.Entity<Belongs>()
                .HasOne(bl => bl.Category)
                .WithMany(c => c.Belongs)
                .HasForeignKey(bl => bl.CategoryId);


            modelBuilder.Entity<Borrows>()
                .HasKey(br => new { br.BookId, br.UserId });

            modelBuilder.Entity<Borrows>()
                .HasOne(br => br.Book)
                .WithMany(b => b.Borrows)
                .HasForeignKey(br => br.BookId);

            modelBuilder.Entity<Borrows>()
                .HasOne(br => br.User)
                .WithMany(u => u.Borrows)
                .HasForeignKey(br => br.UserId);

         
        }
    }
}
