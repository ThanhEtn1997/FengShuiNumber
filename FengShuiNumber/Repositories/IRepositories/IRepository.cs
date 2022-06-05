using FengShuiNumber.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FengShuiNumber.Repositories
{
    public interface IRepository<T1, T2> where T1: class
    {
        List<T1> GetAll();
        List<T1> Find(Expression<Func<T1, bool>> predicate);
        T1 Insert(T1 entity);
        void InsertRange(List<T1> entities);
    }
}
