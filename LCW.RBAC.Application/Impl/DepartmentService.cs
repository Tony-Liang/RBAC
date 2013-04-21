using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Infrastructure;

namespace LCW.RBAC.Application
{
    public class DepartmentService : IDepartmentService
    {
        private ISysDepartmentRepository repository;

        public DepartmentService(ISysDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Entities.SysDepartment> GetDepartments()
        {
            return repository.LoadAll();
        }

        public IEnumerable<Entities.SysDepartment> GetChildDepartments(int Id)
        {
            return repository.GetChildrens(Id);
        }

        public Entities.SysDepartment GetDepartment(int Id)
        {
            return repository.Get(Id);
        }

        public void InsertDepartment(Entities.SysDepartment Department)
        {
            repository.Add(Department);
        }

        public void DeleteDepartment(Entities.SysDepartment Department)
        {
            repository.Remove(Department);
        }

        public void UpdateDepartment(Entities.SysDepartment Department)
        {
            repository.Update(Department);
        }


        public IEnumerable<Entities.SysDepartment> GetDepartments(Framework.Common.NHibernate.CriterionRequest<Entities.SysDepartment> Criterion)
        {
            return repository.Fetch(Criterion);
        }
    }
}
