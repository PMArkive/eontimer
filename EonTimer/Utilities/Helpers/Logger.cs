using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EonTimer.Utilities.Helpers
{
    public static class Logger
    {
        private static readonly String LOG_FILENAME = Environment.CurrentDirectory + "\\EonLog.txt";

        public static void Log(String msg)
        {
            msg = String.Format("{0:G}: {1}\r\n", DateTime.Now, msg);

            File.AppendAllText(LOG_FILENAME, msg);

        }
    }
}
