using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace LCW.RBAC.Infrastructure
{
    public abstract class RepositoryBase<T>:IRepository<T> where T:class
    {
        protected ISession session;

        protected ISession Session
        {
            get
            {
                return session;
            }
        }

        public virtual T Load(object primaryKey)
        {
            return Session.Load<T>(primaryKey);
        }

        public virtual T Get(object primaryKey)
        {
            return Session.Get<T>(primaryKey);
        }

        public virtual T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return Session.Query<T>().First(predicate);
        }

        public virtual IQueryable<T> Find()
        {
            return Session.Query<T>();
        }

        public virtual IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return Session.Query<T>().Where(predicate);
        }

        public virtual T Add(T entity)
        {
            Session.Save(entity);
            return entity;
        }

        public virtual T Remove(T entity)
        {
            Session.Delete(entity);
            return entity;
        }


        public IEnumerable<T> LoadAll()
        {
            return Session.Query<T>().ToList<T>();
        }


        public void Update(T entity)
        {
            Session.SaveOrUpdate(entity);
        }

        //DetachedCriteria
        public IEnumerable<T> Fetch(Framework.Common.NHibernate.CriterionRequest<T> Criterion)
        { 
            ICriteria criterias = this.Session.CreateCriteria<T>();
            if (Criterion.Criterias != null)
            {
                foreach (var exp in Criterion.Criterias)
                {
                    criterias.Add(exp.Compile().Invoke());
                }
            }
            if (Criterion.Associations != null)
            {
                foreach (var aexp in Criterion.Associations)
                {
                    criterias.CreateCriteria(aexp.AssociationPath, aexp.Alias);
                    if (aexp.Criterias != null)
                    {
                        foreach (var child in aexp.Criterias)
                        {
                            criterias.Add(child.Compile().Invoke());
                        }
                    }
                }
            }
            ICriteria totalcriteria = criterias.Clone() as ICriteria;
            Criterion.Totals = totalcriteria.SetProjection(Projections.RowCount()).UniqueResult<int>();
            if (Criterion.Orders != null)
            {
                foreach (var order in Criterion.Orders)
                {
                    criterias.AddOrder(order.Compile().Invoke());
                }               
            }
            if (Criterion.Associations != null)
            {
                foreach (var aexp in Criterion.Associations)
                {
                    if (aexp.Orders != null)
                    {
                        foreach (var child in aexp.Orders)
                        {
                            criterias.AddOrder(child.Compile().Invoke());
                        }
                    }
                }
            }
            criterias.SetFirstResult((Criterion.CurrentPage - 1) * Criterion.PageSize)
                     .SetMaxResults(Criterion.PageSize);
            Criterion.DataList = criterias.List<T>();
            return Criterion.DataList;
        }
    }
}
