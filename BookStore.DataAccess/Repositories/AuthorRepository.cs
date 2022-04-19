using System.Collections.Generic;
using System.Linq;
using BookStore.DataAccess.Infrastructure;
using BookStore.DataModels.Entities;
using BookStore.DataModels.ViewModels;

namespace BookStore.DataAccess.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        /// <summary>
        /// get author by name
        /// </summary>
        /// <param name="name">name of author</param>
        /// <returns></returns>
        public List<Author> GetByName(string name)
        {
            return DbContext.Authors.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}