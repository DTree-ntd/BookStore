using System.Collections.Generic;
using BookStore.Common;
using BookStore.DataAccess.Infrastructure;
using BookStore.DataAccess.Repositories;
using BookStore.DataModels.Entities;
using BookStore.DataModels.ViewModels;
using log4net;

namespace BookStore.Handler
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Log = LogAction.GetLogger();
        public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;

        }
        /// <summary>
        ///  Add a store into table store
        /// </summary>
        /// <param name="store"></param>
        public Store Add(Store store)
        {
            Log.Info("Begin: Add");
            var result = _storeRepository.Add(store);
            Log.Info("End: Add");
            return result;
        }
        /// <summary>
        /// Delete a store
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Log.Info("Begin: Delete");
            var store = _storeRepository.GetSingleById(id);
            _storeRepository.Delete(store);
            Log.Info("End: Delete");
        }
        /// <summary>
        /// Get store by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Store Get(int id)
        {
            Log.Info("Begin: Get");
            var store = _storeRepository.GetSingleById(id);
            Log.Info("End: Get");
            return store;
        }
        /// <summary>
        /// Get all stores in database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Store> GetAll()
        {
            Log.Info("Begin: GetAll");
            var result = _storeRepository.GetAll();
            Log.Info("Begin: GetAll");
            return result;
        }
        /// <summary>
        ///  Get all stores
        /// </summary>
        /// <returns></returns>
        public List<StoreViewModel> GetAllStores()
        {
            Log.Info("Begin: GetAllStores");
            var stores = _storeRepository.GetAllStores();
            Log.Info("End: GetAllStores");
            return stores;
        }
        /// <summary>
        /// Save changes of store
        /// </summary>
        public void SaveChanges()
        {
            Log.Info("Begin: SaveChanges");
            _unitOfWork.Commit();
            Log.Info("End: SaveChange");
        }
        /// <summary>
        /// Update store
        /// </summary>
        /// <param name="store"></param>
        public void Update(Store store)
        {
            Log.Info("Begin: Update");
            _storeRepository.Update(store);
            Log.Info("End: Update");
        }
    }
}