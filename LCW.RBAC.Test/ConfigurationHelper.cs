using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using System.IO;

namespace LCW.RBAC.Test
{
    public static class ConfigurationHelper
    {
        public static readonly string hibernateConfigFile;

        static ConfigurationHelper()
        {
            // Verify if hibernate.cfg.xml exists
            hibernateConfigFile = ConfigurationHelper.GetDefaultConfigurationFilePath();
        }

        public static string GetDefaultConfigurationFilePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string relativeSearchPath = AppDomain.CurrentDomain.RelativeSearchPath;
            string binPath = relativeSearchPath == null ? baseDir : Path.Combine(baseDir, relativeSearchPath);
            string fullPath = Path.Combine(binPath, NHibernate.Cfg.Configuration.DefaultHibernateCfgFileName);
            return File.Exists(fullPath) ? fullPath : null;
        }

        /// <summary>
        /// Standar Configuration for tests.
        /// </summary>
        /// <returns>The configuration using merge between App.Config and hibernate.cfg.xml if present.</returns>
        public static Configuration GetDefaultConfiguration()
        {
            Configuration result = new Configuration();
            if (hibernateConfigFile != null)
                result.Configure(hibernateConfigFile);
            return result;
        }
    }
}
