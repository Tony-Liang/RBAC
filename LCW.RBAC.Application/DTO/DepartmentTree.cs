using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCW.RBAC.Entities;

namespace LCW.RBAC.Application.DTO
{
    public class DepartmentTree
    {
        public DepartmentTree(int id, string text)
        {
            this.Id = id;
            this.Text = text;
            this.Childrens = new List<DepartmentTree>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public IList<DepartmentTree> Childrens { get; set; }

        public DepartmentTree Parent { get; set; }

        public static DepartmentTree Parse(IEnumerable<SysDepartment> departments)
        {
            IList<DepartmentTree> Childrens = new List<DepartmentTree>();
            foreach (var department in departments)
            {
                if (department.ParentId == 0)
                {
                    DepartmentTree tree = new DepartmentTree(department.DepartmentId,department.DepartmentName);
                    Childrens.Add(tree);
                }
            }
            //System.Collections.Hashtable table = new System.Collections.Hashtable();
            foreach (var dep in Childrens)
            {
                InitChildren(dep, departments);
            }
            DepartmentTree root = new DepartmentTree(-1, "Company");
            root.Childrens = Childrens;
            return root;
        }

        private static void InitChildren(DepartmentTree dep, IEnumerable<SysDepartment> departments)
        {
            foreach (var department in departments)
            {
                if (department.ParentId == dep.Id)
                {
                    var temp = new DepartmentTree(department.DepartmentId, department.DepartmentName);
                    temp.Parent = dep;
                    dep.Childrens.Add(temp);
                    InitChildren(temp, departments);
                }
            }
        }
    }
}
