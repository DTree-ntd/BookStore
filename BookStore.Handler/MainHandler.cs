using System;
using BookStore.Common;
using BookStore.DataModels.Entities;
using log4net;

namespace BookStore.Handler
{
    public class MainHandler : IMainHandler
    {
        private readonly IBookService _bookService;
        private readonly IStoreService _storeService;
        private readonly IAuthorService _authorService;
        private static readonly ILog Log = LogAction.GetLogger();

        public MainHandler(IBookService bookService, IAuthorService authorService, IStoreService storeService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _storeService = storeService;
        }
        public object Handle(object sender, string type, string act)
        {
            Log.Info("Begin: Handle");
            try
            {
                switch (type)
                {
                    case Constants.StatusTypes.Book:
                        return BookActions(sender, act);
                    case Constants.StatusTypes.Author:
                        return AuthorActions(sender, act);
                    case Constants.StatusTypes.Store:
                        return StoreActions(sender, act);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Log.Error("Handle Exception: " + e.Message);
                return e.Message;
            }

            Log.Info("End: Handle");
            return null;
        }

        #region CallActions

        private object OrderActions(object sender, string act)
        {
            _mockOrderRepository.Setup(m => m.GetAllOrders()).Returns(_orderViewModels);
            switch (act)
            {
                case Constants.ActionTypes.GetAll:
                    return _orderService.GetAllOrder();

            }

            return null;
        }

        /// <summary>
        ///  call services of book
        /// </summary>
        /// <param name="sender">param of action</param>
        /// <param name="act">action of book</param>
        /// <returns></returns>
        private object BookActions(object sender, string act)
        {
            var book = new Book()
            {
                Price = 456.34m,
                Quantity = 456,
                Id = 1,
                AuthorId = 2,
                Name = "Book 1"

            };

            switch (act)
            {
                case Constants.ActionTypes.GetAll:
                    return _bookService.GetAll();
                case Constants.ActionTypes.GetAllBooks:
                    return _bookService.GetAllBooks();


            }
            return null;
        }
        /// <summary>
        /// call services of author
        /// </summary>
        /// <param name="sender">param of action</param>
        /// <param name="act">action of author</param>
        /// <returns></returns>
        private object AuthorActions(object sender, string act)
        {

            switch (act)
            {
                case Constants.ActionTypes.GetAll:
                    return _authorService.GetAll();
                case Constants.ActionTypes.GetByName:
                    return _authorService.GetByName(sender.ToString());

            }
            return null;
        }
        #endregion
    }
}