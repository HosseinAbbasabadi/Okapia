using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework
{
    public interface IRepository<in TKey, T>
    {
        T Get(TKey id);
        List<T> GetAll();
        List<T> Get(Expression<Func<T, bool>> predicate);
        void Create(T aggregate);
        void Update(T aggregate);
        void Delete(T aggregate);
        long GetNextId(string sequenceName);
    }

}
