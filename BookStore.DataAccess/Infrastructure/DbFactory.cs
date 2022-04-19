namespace BookStore.DataAccess.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BookStoreContext _context;

        public DbFactory()
        {
        }
        
        protected override void DisposeCore()
        {
            _context?.Dispose();
        }
        /// <summary>
        /// init instance of context
        /// </summary>
        /// <returns></returns>
        public BookStoreContext Init()
        {
            return _context ?? (_context = new BookStoreContext());
        }
    }
}