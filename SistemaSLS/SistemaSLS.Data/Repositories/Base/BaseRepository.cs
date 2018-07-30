using SistemaSLS.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaSLS.Data.Repositories.Base
{
    public abstract class BaseRepository<C, T> : IBaseRepository<T>
       where T : class
        where C : ISlsContext
    {
        private C _context;

        public C Context
        {
            get { return _context; }
            set { _context = value; }
        }


        protected readonly IDbSet<T> _dbSet;

        protected BaseRepository(C context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Add(List<T> entity)
        {
            foreach (var item in entity)
            {
                _dbSet.Add(item);
            }
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual void Delete(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> list = _dbSet.Where<T>(condition).AsEnumerable();
            foreach (T item in list)
                this.Delete(item);
        }

        public virtual T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual T GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> condition)
        {
            return await _dbSet.Where<T>(condition).ToListAsync();
        }

        public virtual async Task<T> GetByCondition(Expression<Func<T, bool>> condition)
        {
            return await _dbSet.Where<T>(condition).FirstOrDefaultAsync();
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
