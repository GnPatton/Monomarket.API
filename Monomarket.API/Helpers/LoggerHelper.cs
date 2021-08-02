using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monomarket.API.Helpers
{
    public static class LoggerHelper
    {
        public static void ConfigureDatabase(string connectionString)
        {
            var databaseTarget = (DatabaseTarget)LogManager.Configuration.FindTargetByName("database");
            if (databaseTarget != null)
            {
                databaseTarget.ConnectionString = connectionString;
                LogManager.ReconfigExistingLoggers();
            }
        }
    }
}
