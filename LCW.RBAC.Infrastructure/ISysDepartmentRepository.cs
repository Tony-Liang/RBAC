using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Entities;

namespace LCW.RBAC.Infrastructure
{
    public interface ISysDepartmentRepository : IRepository<SysDepartment>
    {
        IEnumerable<SysDepartment> GetChildrens(int Id);
    }
}
