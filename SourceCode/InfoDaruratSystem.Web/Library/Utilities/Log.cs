using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

//using Microsoft.ExtensionsPlatformAbstractions;

using System.IO;
using System.Data;

namespace InfoDaruratSystem.Web.Library.Utilities
{
    public class Log
    {

        public static void WriteLog(string strLog, IHostingEnvironment hosting)
        {

            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            var logFilePath = hosting.WebRootPath + "/Logs/Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";

            logFileInfo = new FileInfo(logFilePath.ToString());
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();

            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }

            log = new StreamWriter(fileStream);
            log.WriteLine(strLog + " ----- " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"));

            log.Dispose();
        }

    }
}
