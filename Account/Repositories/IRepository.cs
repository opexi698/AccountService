using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Account.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetFirst();

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null);

        void Add(T entity);

        void Remove(T entity);
    }
}