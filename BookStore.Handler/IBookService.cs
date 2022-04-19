using System.Collections.Generic;
using BookStore.DataModels.Entities;
using BookStore.DataModels.ViewModels;

namespace BookStore.Handler
{
    public interface IBookService : IBaseService<Book>
    {
        List<BookViewModel> GetAllBooks();
    }
}