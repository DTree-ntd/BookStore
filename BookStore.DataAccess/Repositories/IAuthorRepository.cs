using System.Collections.Generic;
using BookStore.DataAccess.Infrastructure;
using BookStore.DataModels.Entities;

namespace BookStore.DataAccess.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        List<Author> GetByName(string name);
    }
}