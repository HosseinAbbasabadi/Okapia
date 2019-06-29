using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework;

namespace Okapia.Repository.Repositories
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly OkapiaContext _context;

        public BaseRepository(OkapiaContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public long GetNextId(string sequenceName)
        {
            //return _context.GetNextSequence(sequenceName);    
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}