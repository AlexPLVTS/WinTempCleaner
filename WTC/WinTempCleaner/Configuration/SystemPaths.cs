using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTempCleaner.Configuration
{
    public static class SystemPaths
    {
        public static string TempFolderPath { get; }
        public static string SystemDriveRoot { get; }

        public static DirectoryInfo TempFolderDirectoryInfo { get; }

        static SystemPaths()
        {
            TempFolderPath = Path.GetTempPath();
            SystemDriveRoot = Path.GetPathRoot(TempFolderPath);
            TempFolderDirectoryInfo = new DirectoryInfo(TempFolderPath);
        }
    }
}
