using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaSLS.Data.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {



        void Add(T entity);
        void Add(List<T> entity);
        void Update(T entity);

        void Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        void Delete(Expression<Func<T, bool>> condition);

        T GetById(long id);
        T GetById(string id);
        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> condition);

        Task<T> GetByCondition(Expression<Func<T, bool>> condition);
        void SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
