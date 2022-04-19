using System;
using System.Collections.Generic;
using BookStore.Common;
using BookStore.DataAccess.Infrastructure;
using BookStore.DataAccess.Repositories;
using BookStore.DataModels.Entities;
using BookStore.DataModels.ViewModels;
using log4net;

namespace BookStore.Handler
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Log = LogAction.GetLogger();
        public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;

        }
        /// <summary>
        ///  Add a book into table book
        /// </summary>
        /// <param name="book"></param>
        public Book Add(Book book)
        {
            Log.Info("Begin: Add");
            var result = _bookRepository.Add(book);
            Log.Info("End: Add");
            return result;
        }
        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Log.Info("Begin: Delete");
            var book = _bookRepository.GetSingleById(id);
            _bookRepository.Delete(book);
            Log.Info("End: Delete");
        }
        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book Get(int id)
        {
            Log.Info("Begin: Get");
            var book = _bookRepository.GetSingleById(id);
            Log.Info("End: Get");
            return book;
        }
        /// <summary>
        /// Get all books in database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetAll()
        {
            Log.Info("Begin: GetAll");
            var result = _bookRepository.GetAll();
            Log.Info("Begin: GetAll");
            return result;
        }
        /// <summary>
        ///  Get all books
        /// </summary>
        /// <returns></returns>
        public List<BookViewModel> GetAllBooks()
        {
            Log.Info("Begin: GetAllBooks");
            var books = _bookRepository.GetAllBooks();
            Log.Info("End: GetAllBooks");
            return books;
        }
        /// <summary>
        /// Save changes of book
        /// </summary>
        public void SaveChanges()
        {
            Log.Info("Begin: SaveChanges");
            _unitOfWork.Commit();
            Log.Info("End: SaveChange");
        }
        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="book"></param>
        public void Update(Book book)
        {
            Log.Info("Begin: Update");
            _bookRepository.Update(book);
            Log.Info("End: Update");
        }
    }
}