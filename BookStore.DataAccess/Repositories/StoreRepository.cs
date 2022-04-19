using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookStore.DataAccess.Infrastructure;
using BookStore.DataModels.Entities;
using BookStore.DataModels.ViewModels;

namespace BookStore.DataAccess.Repositories
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }


        public List<StoreViewModel> GetAllStores()
        {
            var stores = DbContext.Stores.Select(x => new StoreViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
            }).ToList();
            
            return stores;
        }
    }
}