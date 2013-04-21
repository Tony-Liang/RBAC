using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Infrastructure;

namespace LCW.RBAC.Application
{
    public class AccountService:IAccountService
    {
        ISysUserRepository service;
        public AccountService(ISysUserRepository service)
        {
            this.service = service;
        }

        public void InsertAccount(Entities.SysUser account)
        {
            service.Add(account);
        }

        public void UpdateAccount(Entities.SysUser account)
        {
            service.Update(account);
        }

        public void DeleteAccount(Entities.SysUser account)
        {
            service.Remove(account);
        }

        public IEnumerable<Entities.SysUser> GetAccounts()
        {
            return service.LoadAll();
        }

        public Entities.SysUser FindAccount(int Id)
        {
            return service.Get(Id);
        }


        public IEnumerable<Entities.SysUser> GetAccounts(Framework.Common.NHibernate.CriterionRequest<Entities.SysUser> Criterion)
        {
            return service.Fetch(Criterion);
        }
    }
}
