using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Infrastructure;

namespace LCW.RBAC.Application
{
    public class PositionService : IPositionService
    {
        private ISysPositionRepository repository;
        public PositionService(ISysPositionRepository repository)
        {
            this.repository = repository;
        }

        public void Insert(Entities.SysPosition position)
        {
            this.repository.Add(position);
        }

        public void Update(Entities.SysPosition position)
        {
            this.repository.Update(position);
        }

        public void Delete(Entities.SysPosition position)
        {
            this.repository.Remove(position);
        }

        public IEnumerable<Entities.SysPosition> LoadAll()
        {
            return this.repository.LoadAll();
        }

        public Entities.SysPosition GetPosition(int Id)
        {
            return this.repository.Get(Id);
        }

        public IEnumerable<Entities.SysPosition> Fetch(Framework.Common.NHibernate.CriterionRequest<Entities.SysPosition> Criterion)
        {
            return this.repository.Fetch(Criterion);
        }
    }
}
