using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Infrastructure;

namespace LCW.RBAC.Application
{
    public class PositionCategoryService : IPositionCategoryService
    {
        ISysPositionCategoryRepository respository;
        public PositionCategoryService(ISysPositionCategoryRepository respository)
        {
            this.respository = respository;
        }

        public void Insert(Entities.SysPositionCategory category)
        {
            this.respository.Add(category);
        }

        public void Delete(Entities.SysPositionCategory category)
        {
            this.respository.Remove(category);
        }

        public void Update(Entities.SysPositionCategory category)
        {
            this.respository.Update(category);
        }

        public Entities.SysPositionCategory GetCategory(int Id)
        {
            return this.respository.Get(Id);
        }

        public IEnumerable<Entities.SysPositionCategory> LoadAll()
        {
            return this.respository.LoadAll();
        }

        public IEnumerable<Entities.SysPositionCategory> Fetch(Framework.Common.NHibernate.CriterionRequest<Entities.SysPositionCategory> Criterion)
        {
            return this.respository.Fetch(Criterion);
        }
    }
}
