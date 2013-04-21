using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Entities;
using NHibernate;

namespace LCW.RBAC.Infrastructure.Impl
{
    public class SysUserRepository : RepositoryBase<SysUser>, ISysUserRepository
    {
        public SysUserRepository(ISession session)
        {
            this.session = session;
        }
    }
}
