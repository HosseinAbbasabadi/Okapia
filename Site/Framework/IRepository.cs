using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework
{
    public interface IRepository<in TKey, T>
    {
        T Get(TKey id);
        List<T> GetAll();
        List<T> Get(params Expression<Func<T, bool>>[] predicate);
        bool IsDuplicated(params Expression<Func<T, bool>>[] predicates);
        bool Exists(params Expression<Func<T, bool>>[] predicates);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        long GetNextId(string sequenceName);
        void SaveChanges();
    }

}
