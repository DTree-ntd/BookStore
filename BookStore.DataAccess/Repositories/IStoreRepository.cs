using System.Collections.Generic;
using BookStore.DataAccess.Infrastructure;
using BookStore.DataModels.Entities;
using BookStore.DataModels.ViewModels;

namespace BookStore.DataAccess.Repositories
{
    public interface IStoreRepository : IRepository<Store>
    {
        List<StoreViewModel> GetAllStores();
    }
}