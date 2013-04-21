using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Engine;

namespace LCW.RBAC.Test
{
    public abstract class DatabaseSetup
    {
        protected Configuration cfg;
        protected ISessionFactoryImplementor sessions;
        [TestFixtureSetUp]
        public void init()
        {
            cfg = new Configuration();
            if (ConfigurationHelper.hibernateConfigFile != null)
                cfg.Configure(ConfigurationHelper.hibernateConfigFile);
            BuildSessionFactory();
        }

        protected virtual void BuildSessionFactory()
        {
            try
            {
                sessions = (ISessionFactoryImplementor)cfg.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [SetUp]
        public void SetUp()
        {
            //OnSetUp();
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
