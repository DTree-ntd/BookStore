namespace BookStore.DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}