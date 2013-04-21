using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LCW.RBAC.Entities;
using LCW.RBAC.Infrastructure.Impl;
using LCW.RBAC.Infrastructure;

namespace LCW.RBAC.Test
{
    public class Class1:DatabaseSetup
    {
        public NHibernate.ISession Session
        {
            get
            {
               return sessions.OpenSession();
            }
        }
        [Test]
        public void Connection()
        {
            SysUser u = new SysUser();
            u.LoginName = "liang";
            u.Password = "7777";
            u.Status =2;

            SysUserDetail de = new SysUserDetail();
            de.SysUser = u;
            de.Sex = 0;
            de.Remark = "";
            de.CreateDate = de.ModifiedDate = DateTime.Now;
            de.BirthDay = DateTime.Now;
            de.CName = "wang";
            de.CompanyMail = "liang@126.com";
            de.Email = "wang@126.com";
            de.EName = "yus";
            de.Extension = "232";
            de.HomeTel = "";
            de.IDCard = "441723198810212436";
            de.Mobile = "13456789876";
            de.Type = 0;
            de.UserNO = "c0885";
            de.WorkStartDate = de.WorkEndDate = DateTime.Now;
            u.SysUserDetail = de;
            Session.Save(u);
            //s.Save(de);
        }

        [Test]
        public void Fetch()
        {
            var f = Session.Load<SysUser>(4);
        }

        [Test]
        public void DetailFetch()
        {
            var f = Session.Load<SysUserDetail>(2);
        }

        [Test]
        public void PositionFetch()
        {
            SysPositionCategory category = new SysPositionCategory();

            SysPosition position = new SysPosition();
            position.CreateDate = position.ModifiedDate = DateTime.Now;
            position.OrderBy = new Random().Next(100);
            position.PositionDescription = "java软件工程师";
            position.PositionName = "java软件工程师";
            position.Status =Convert.ToByte(new Random().Next(4));
            position.SysPositionCategory = category;

            SysPosition position2 = new SysPosition();
            position2.CreateDate = position2.ModifiedDate = DateTime.Now;
            position2.OrderBy = new Random().Next(50);
            position2.PositionDescription = "C软件工程师";
            position2.PositionName = "C软件工程师";
            position2.Status = Convert.ToByte(new Random().Next(4));
            position2.SysPositionCategory = category;

            
            category.CategoryName = "计算机";
            category.CreateDate = category.ModifiedDate = DateTime.Now;
            category.OrderBy = 1;
            category.Status = 1;
            category.SysPositionList = new List<SysPosition>();
            category.SysPositionList.Add(position);
            category.SysPositionList.Add(position2);

            Session.Save(category);
        }

        [Test]
        public void PositionSelect()
        {
            SysPosition p=Session.Get<SysPosition>(4);
            SysPosition p2 = Session.Get<SysPosition>(5);

            SysPositionCategory p3 = Session.Get<SysPositionCategory>(3);
        }

        [Test]
        public void Department()
        {
            SysDepartment dep = new SysDepartment();
            dep.CreateDate = dep.ModifiedDate = DateTime.Now;
            dep.DepartmentDescription = "";
            dep.DepartmentName="softEngine";
            dep.OrderBy=1;
            dep.ParentId=0;
            dep.Status=Convert.ToByte(new Random().Next(10));
            Session.Save(dep);
        }

        [Test]
        public void GroupUser()
        {
            SysGroup TEMP=Session.Get<SysGroup>(3);

            //SysGroup g = new SysGroup();
            //g.CreateDate = g.ModifiedDate = DateTime.Now;
            //g.GroupName = "测试组";
            //g.OrderBy = 1;
            //g.Status = Convert.ToByte(new Random().Next(4));
            //g.SysUserGroupList=new List<SysUserGroup>();

            SysUserGroup gu = new SysUserGroup();
            gu.SysGroup = TEMP;
            SysUser u = Session.Get<SysUser>(5);
            gu.SysUser = u;

            //g.SysUserGroupList.Add(gu);

            Session.Save(gu);
        }

        [Test]
        public void Repository()
        {
            IAuthenticationRepository a = new AuthenticationRepository();
            var f=a.Find(null);
        }
    }
}
