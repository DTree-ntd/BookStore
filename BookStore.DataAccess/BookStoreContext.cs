using System.Data.Entity;
using BookStore.DataModels.Entities;

namespace BookStore.DataAccess
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
