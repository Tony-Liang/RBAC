using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCW.RBAC.Application;
using LCW.Framework.Common.NHibernate;
using LCW.RBAC.Infrastructure.Impl;
using LCW.RBAC.Entities;

namespace LCW.RBAC.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private IAccountService service;
        private IDepartmentService depservice;
        private IPositionService posservice;

        public AccountController()
        {
            service = new AccountService(new SysUserRepository(NHibernateSessionManager.CurrentSession));
            depservice = new DepartmentService(new SysDepartmentRepository(NHibernateSessionManager.CurrentSession));
            posservice = new PositionService(new SysPositionRepository(NHibernateSessionManager.CurrentSession));
        }

        public ActionResult Index()
        {
            CriterionRequest<SysUser> criterion = new CriterionRequest<SysUser>();
            GetRequestParams(criterion, "LoginName");
            IEnumerable<SysUser> datalist = service.GetAccounts(criterion);
            return View(criterion);
        }

        private void GetRequestParams<T>(CriterionRequest<T> criterion,params string[] keywork)
        {
            criterion.PageSize = Convert.ToInt32(Request.Form["numPerPage"]??"10");
            criterion.CurrentPage =Convert.ToInt32(Request.Form["pageNum"]??"1");
            string orderby= Request.Form["orderField"] ?? "";
            string direction= Request.Form["orderDirection"] ?? "";
            string keyWords = Request.Form["keywords"] ?? "";
            ViewData["orderby"] = orderby;
            //direction = direction == "desc" ? "asc" : "desc";
            ViewData["direction"] = direction;
            ViewData["keyword"] = keyWords;
            if (!string.IsNullOrEmpty(keyWords))
            {
                var exp=NHibernate.Criterion.Expression.Disjunction();
                foreach (string str in keywork)
                {
                    exp.Add(NHibernate.Criterion.Expression.Like(str,keyWords));
                }
                criterion.Criterias=new System.Linq.Expressions.Expression<Func<NHibernate.Criterion.ICriterion>>[]{
                    ()=>exp
                };
            }
            if(!string.IsNullOrEmpty(orderby))
            {
                criterion.Orders = new System.Linq.Expressions.Expression<Func<NHibernate.Criterion.Order>>[]
                {
                    ()=>direction=="asc"?NHibernate.Criterion.Order.Asc(orderby):NHibernate.Criterion.Order.Desc(orderby)
                };
            }
        }

        public ActionResult AccountDetail()
        {
            int id=Convert.ToInt32(Request["id"]??"0");
            SysUser user=new SysUser();
            if (id > 0)
            {
                user=service.FindAccount(id);
            }
            return View(user);
        }

        public ActionResult AddAccount()
        {
            return View("AccountDetail");
        }

        public ActionResult Save()
        {
            int Id=Convert.ToInt32(Request["UserId"]??"0");
            //Request["UserNO"];
            string LoginName=Request["LoginName"]??"";
            string CName=Request["CName"]??"";
            int sex=Convert.ToInt32(Request["sex"]??"1");
            int type=Convert.ToInt32(Request["type"]??"0");
            string EName=Request["EName"]??"";
            string IDCard=Request["IDCard"]??"";
            string BirthDay=Request["BirthDay"]??"";
            string Email=Request["Email"]??"";
            string CompanyMail=Request["CompanyMail"]??"";
            string Mobile=Request["Mobile"]??"";
            string Extension=Request["Extension"]??"";
            string HomeTel=Request["HomeTel"]??"";
            string WorkStartDate=Request["WorkStartDate"]??"";
            string WorkEndDate=Request["WorkEndDate"]??"";
            int department=Convert.ToInt32(Request["district.id"]??"0");
            int position=Convert.ToInt32(Request["categoryposition.id"]??"0");
            string remark=Request["remark"]??"";
            DateTime now=DateTime.Now;
            SysUser user=null;
            if(Id>0)
            {
                user=service.FindAccount(Id);
                user.LoginName=LoginName;                
            }else
            {
                user=new SysUser();
                user.LoginName=LoginName;
                user.Password=System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456","MD5");//System.Security.Cryptography.MD5
                user.Status=1;
                user.SysUserDetail=new SysUserDetail();
                user.SysUserDetail.SysUser=user;
                user.SysUserDetail.CreateDate=now;
                user.SysUserDetail.UserNO = "988";
            }
            if(user!=null && user.SysUserDetail!=null)
            {
                user.SysUserDetail.BirthDay=DateTime.Parse(BirthDay);
                user.SysUserDetail.CName=CName;
                user.SysUserDetail.CompanyMail=CompanyMail;
                user.SysUserDetail.Email=Email;
                user.SysUserDetail.EName=EName;
                user.SysUserDetail.Extension=Extension;
                user.SysUserDetail.HomeTel=HomeTel;
                user.SysUserDetail.IDCard=IDCard;
                user.SysUserDetail.Mobile=Mobile;
                user.SysUserDetail.ModifiedDate=now;
                user.SysUserDetail.Remark=remark;
                user.SysUserDetail.WorkStartDate = WorkStartDate==""?new Nullable<DateTime>():Convert.ToDateTime(WorkStartDate);
                user.SysUserDetail.WorkEndDate = WorkStartDate == "" ? new Nullable<DateTime>() : Convert.ToDateTime(WorkStartDate);
                user.SysUserDetail.Sex=Convert.ToByte(sex);
                if(department>0)
                {
                    var dep=depservice.GetDepartment(department);
                    if(dep!=null)
                    user.SysUserDetail.SysDepartment=dep;
                }
                if(position>0)
                {
                    var pos=posservice.GetPosition(position);
                    if(pos!=null)
                        user.SysUserDetail.SysPosition=pos;
                }
                user.SysUserDetail.Type=Convert.ToByte(type);
                if(user.UserId>0)
                    service.UpdateAccount(user);
                else
                    service.InsertAccount(user);
            }
            return View();
        }
    }   
}
