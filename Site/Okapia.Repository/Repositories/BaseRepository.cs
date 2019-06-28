using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework;

namespace Okapia.Repository.Repositories
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T > where T : class
    {
        private readonly OkapiaContext _context;

        public BaseRepository(OkapiaContext context)
        {
            _context = context;
        }

        public void Create(T aggregate)
        {
            _context.Add(aggregate);
        }

        public void Update(T aggregate)
        {
            _context.Update(aggregate);
        }

        public void Delete(T aggregate)
        {
            _context.Remove(aggregate);
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Query<T>().Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Query<T>().ToList();
        }

        public long GetNextId(string sequenceName)
        {
            //return _context.GetNextSequence(sequenceName);
            throw new NotImplementedException();
        }
    }
}