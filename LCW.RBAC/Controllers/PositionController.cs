using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCW.RBAC.Application;
using LCW.RBAC.Infrastructure.Impl;
using LCW.Framework.Common.NHibernate;

namespace LCW.RBAC.Controllers
{
    public class PositionController : Controller
    {
        //
        // GET: /Position/
        IPositionCategoryService service;
        public PositionController()
        {
            service = new PositionCategoryService(new SysPositionCategoryRepository(NHibernateSessionManager.CurrentSession));
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tree()
        {
            IEnumerable<LCW.RBAC.Entities.SysPositionCategory> datalist = service.LoadAll();
            return View(datalist);
        }
    }
}
