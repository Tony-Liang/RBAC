using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Entities;

namespace LCW.RBAC.Application
{
    public interface IPositionService
    {
        void Insert(SysPosition position);
        void Update(SysPosition position);
        void Delete(SysPosition position);

        IEnumerable<SysPosition> LoadAll();
        SysPosition GetPosition(int Id);
        IEnumerable<SysPosition> Fetch(Framework.Common.NHibernate.CriterionRequest<SysPosition> Criterion);
    }
}
