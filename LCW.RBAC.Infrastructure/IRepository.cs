using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using LCW.Framework.Common.NHibernate;

namespace LCW.RBAC.Infrastructure
{
    public interface IRepository<T>
    {
        T Load(object primaryKey);
        T Get(object primaryKey);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> LoadAll();
        IQueryable<T> Find();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Remove(T entity);
        void Update(T entity);
        IEnumerable<T> Fetch(CriterionRequest<T> Criterion);
    }
}
