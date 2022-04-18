namespace BookStore.DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private BookStoreContext _dbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }
        public BookStoreContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        /// <summary>
        /// save change to database
        /// </summary>
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}