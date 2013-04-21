using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Entities;
using NHibernate;

namespace LCW.RBAC.Infrastructure.Impl
{
    public class SysDepartmentRepository : RepositoryBase<SysDepartment>, ISysDepartmentRepository
    {
        public SysDepartmentRepository(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<SysDepartment> GetChildrens(int Id)
        {
            return Session.CreateCriteria<SysDepartment>().Add(NHibernate.Criterion.Expression.Eq("ParentId", Id)).List<SysDepartment>();
        }
    }
}
