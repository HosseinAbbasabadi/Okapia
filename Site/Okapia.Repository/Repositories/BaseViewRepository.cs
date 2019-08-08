using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework;

namespace Okapia.Repository.Repositories
{
    public class BaseViewRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        public OkapiaViewContext _context;

        public BaseViewRepository(OkapiaViewContext context)
        {
            _context = context;
        }

        public bool Exists(params Expression<Func<T, bool>>[] predicates)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var predicate in predicates)
            {
                query = query.Where(predicate);
            }

            return query.Any();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Attach(T entity)
        {
            _context.Attach(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> Get(params Expression<Func<T, bool>>[] predicates)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var predicate in predicates)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        public bool IsDuplicated(params Expression<Func<T, bool>>[] predicates)
        {
            var enity = Get(predicates);
            return enity.Count > 0;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public long GetNextId(string sequenceName)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}