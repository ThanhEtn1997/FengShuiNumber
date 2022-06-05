using FengShuiNumber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FengShuiNumber.Repositories
{
    public class Repository<T1, T2> : IRepository<T1, T2> where T1 : class
    {
        protected readonly FengShuiNumberDbContext _context;
        public Repository(FengShuiNumberDbContext context) => _context = context;

        public List<T1> Find(Expression<Func<T1, bool>> predicate)
        {
            return _context.Set<T1>().Where(predicate).ToList();
        }
        public List<T1> GetAll()
        {
            return _context.Set<T1>().ToList();
        }

        public T1 Insert(T1 entity)
        {
            var res = _context.Set<T1>().Add(entity);
            _context.SaveChanges();
            return res.Entity;
        }

        public void InsertRange(List<T1> entities)
        {
            _context.Set<T1>().AddRange(entities);
            _context.SaveChanges();
        }
    }
}
