using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMWCompetencyTest.Helpers
{
    public static class ProcessLog
    {
        private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void logInfo(string text)
        {
            log.Info(text);
        }

        public static void logError(string text)
        {
            log.Error(text);
        }
    }
}
