using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCW.RBAC.Application;
using LCW.RBAC.Entities;
using LCW.RBAC.Infrastructure.Impl;
using LCW.Framework.Common.NHibernate;
using LCW.RBAC.Application.DTO;

namespace LCW.RBAC.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        private IDepartmentService service;
        public DepartmentController()
        {
            service = new DepartmentService(new SysDepartmentRepository(NHibernateSessionManager.CurrentSession));
        }

        public ActionResult Index()
        {
            IEnumerable<SysDepartment> datalist = service.GetDepartments();
            var root=DepartmentTree.Parse(datalist);
            return View(root);
        }

        public ActionResult Tree()
        {
            IEnumerable<SysDepartment> datalist = service.GetDepartments();
            var root = DepartmentTree.Parse(datalist);
            return View(root);
        }
    }
}
