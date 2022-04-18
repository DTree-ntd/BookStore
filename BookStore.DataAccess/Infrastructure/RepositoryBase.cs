using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.DataAccess.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private BookStoreContext _dataContext;
        private readonly IDbSet<T> _dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected BookStoreContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        #region Implementation
        /// <summary>
        /// Add a entity
        /// </summary>
        /// <param name="entity">entity will add</param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity);
        }
        /// <summary>
        /// Update a entity
        /// </summary>
        /// <param name="entity">new info a entity want add</param>
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <param name="entity">entity want delete</param>
        /// <returns></returns>
        public virtual T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }
        /// <summary>
        /// Delete a entity by id
        /// </summary>
        /// <param name="id">id of entity want delete</param>
        /// <returns></returns>
        public virtual T Delete(int id)
        {
            var entity = _dbSet.Find(id);
            return _dbSet.Remove(entity);
        }
        /// <summary>
        /// Delete multi entity
        /// </summary>
        /// <param name="where">express of condition find entity</param>
        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }
        /// <summary>
        /// get single entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetSingleById(int id)
        {
            return _dbSet.Find(id);
        }
        /// <summary>
        /// get many entity by condition or things to take
        /// </summary>
        /// <param name="where">condition</param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes)
        {
            return _dbSet.Where(where).ToList();
        }

        /// <summary>
        /// Count number  by condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return _dbSet.Count(where);
        }
        /// <summary>
        /// Get all and include
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = _dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return _dataContext.Set<T>().AsQueryable();
        }
        /// <summary>
        /// get single entity by condition
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Length > 0)
            {
                var query = _dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return _dataContext.Set<T>().FirstOrDefault(expression);
        }
        /// <summary>
        /// get multiple entity
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = _dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return _dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }
        /// <summary>
        /// Get multi paging entity
        /// </summary>
        /// <param name="predicate">condition</param>
        /// <param name="total">total of items</param>
        /// <param name="index">page index</param>
        /// <param name="size">page size</param>
        /// <param name="includes">somethings want take</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = _dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                resetSet = predicate != null ? _dataContext.Set<T>().Where<T>(predicate).AsQueryable() : _dataContext.Set<T>().AsQueryable();
            }

            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }
        /// <summary>
        /// Count number of entity by condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return _dataContext.Set<T>().Count<T>(predicate) > 0;
        }
        #endregion
    }
}
