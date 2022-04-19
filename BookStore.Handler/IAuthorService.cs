using System.Collections.Generic;
using BookStore.DataModels.Entities;

namespace BookStore.Handler
{
    public interface IAuthorService : IBaseService<Author>
    {
        List<Author> GetByName(string alias);
    }
}