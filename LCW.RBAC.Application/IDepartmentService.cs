using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Entities;

namespace LCW.RBAC.Application
{
    public interface IDepartmentService
    {
        IEnumerable<SysDepartment> GetDepartments();
        IEnumerable<SysDepartment> GetDepartments(Framework.Common.NHibernate.CriterionRequest<SysDepartment> Criterion);

        IEnumerable<SysDepartment> GetChildDepartments(int Id);

        SysDepartment GetDepartment(int Id);

        void InsertDepartment(SysDepartment Department);

        void DeleteDepartment(SysDepartment Department);

        void UpdateDepartment(SysDepartment Department);
    }
}
