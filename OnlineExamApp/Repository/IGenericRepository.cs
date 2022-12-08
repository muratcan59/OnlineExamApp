using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace OnlineExamApp.Repository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
