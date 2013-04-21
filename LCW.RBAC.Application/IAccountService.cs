using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Entities;

namespace LCW.RBAC.Application
{
    public interface IAccountService
    {
        void InsertAccount(SysUser account);
        void UpdateAccount(SysUser account);
        void DeleteAccount(SysUser account);

        IEnumerable<SysUser> GetAccounts();
        IEnumerable<SysUser> GetAccounts(Framework.Common.NHibernate.CriterionRequest<SysUser> Criterion);
        SysUser FindAccount(int Id);
    }
}
