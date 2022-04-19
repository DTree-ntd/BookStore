using System.Collections.Generic;
using BookStore.DataModels.Entities;
using BookStore.DataModels.ViewModels;

namespace BookStore.Handler
{
    public interface IStoreService : IBaseService<Store>
    {
        List<StoreViewModel> GetAllStores();
    }
}