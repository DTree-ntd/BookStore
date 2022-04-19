using System.Collections.Generic;
using BookStore.Common;
using BookStore.DataAccess.Infrastructure;
using BookStore.DataAccess.Repositories;
using BookStore.DataModels.Entities;
using log4net;

namespace BookStore.Handler
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Log = LogAction.GetLogger();
        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Add an author
        /// </summary>
        /// <param name="author"></param>
        public Author Add(Author author)
        {
            Log.Info("Begin: Add");
            var result = _authorRepository.Add(author);
            Log.Info("End: Add");
            return result;
        }
        /// <summary>
        /// Delete an author by id
        /// </summary>
        /// <param name="id">id of author</param>
        public void Delete(int id)
        {
            Log.Info("Begin: Delete");
            var author = _authorRepository.GetSingleById(id);
            if (author != null)
                _authorRepository.Delete(author);
            Log.Info("End: Delete");
        }
        /// <summary>
        /// get an author by id
        /// </summary>
        /// <param name="id">id of author</param>
        /// <returns></returns>
        public Author Get(int id)
        {
            Log.Info("Begin: Get");
            var author = _authorRepository.GetSingleById(id);
            Log.Info("End: Get");
            return author;
        }
        /// <summary>
        /// Get all authors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Author> GetAll()
        {
            Log.Info("Begin: GetAll");
            var authors = _authorRepository.GetAll();
            Log.Info("End: GetAll");
            return authors;
        }
        /// <summary>
        /// Get author by name
        /// </summary>
        /// <param name="name">name of author</param>
        /// <returns></returns>
        public List<Author> GetByName(string name)
        {

            Log.Info("Begin: GetByName");
            var authors = _authorRepository.GetByName(name);
            Log.Info("End: GetByName");
            return authors;
        }
        /// <summary>
        /// SaveChanges of table author
        /// </summary>
        public void SaveChanges()
        {
            Log.Info("Begin: SaveChanges");
            _unitOfWork.Commit();
            Log.Info("End: SaveChanges");
        }
        /// <summary>
        /// Update an author
        /// </summary>
        /// <param name="author"></param>
        public void Update(Author author)
        {
            Log.Info("Begin: Update");
            _authorRepository.Update(author);
            Log.Info("End: Update");
        }
    }
}