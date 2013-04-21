using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Entities;

namespace LCW.RBAC.Application
{
    public interface IPositionCategoryService
    {
        void Insert(SysPositionCategory category);
        void Delete(SysPositionCategory category);
        void Update(SysPositionCategory category);

        SysPositionCategory GetCategory(int Id);
        IEnumerable<SysPositionCategory> LoadAll();
        IEnumerable<SysPositionCategory> Fetch(Framework.Common.NHibernate.CriterionRequest<SysPositionCategory> Criterion);

    }
}
