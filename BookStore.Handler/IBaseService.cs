using System.Collections.Generic;

namespace BookStore.Handler
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Delete(int id);
        void Update(T customer);
        void SaveChanges();
        T Add(T customer);
    }
}