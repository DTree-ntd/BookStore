using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookStore.DataAccess.Infrastructure;
using BookStore.DataModels.Entities;
using BookStore.DataModels.ViewModels;

namespace BookStore.DataAccess.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        public List<BookViewModel> GetAllBooks()
        {
            var books = DbContext.Books.Include(x => x.Author).Select(x => new BookViewModel()
            {
                AuthorName = x.Author.Name,
                Name = x.Name,
                Id = x.Id,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList();

            return books;
        }
    }
}
