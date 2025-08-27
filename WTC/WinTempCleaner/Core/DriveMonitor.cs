using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinTempCleaner.Configuration;

namespace WinTempCleaner.Core
{
    public static class DriveMonitor
    {
        public static long GetSystemDriveFreeSpacePercentage()
        {
            try
            {
                DriveInfo systemDrive = GetSystemDriveInfo();
                if (systemDrive != null && systemDrive.IsReady)
                {
                    return (systemDrive.AvailableFreeSpace * 100) / systemDrive.TotalSize;
                }
            }
            catch { }
            return -1;
        }

        public static DriveInfo GetSystemDriveInfo()
        {
            try
            {
                return new DriveInfo(SystemPaths.SystemDriveRoot);
            }
            catch
            {
                return null;
            }
        }
        public static long GetTempFolderSizeInBytes()
        {
            DirectoryInfo dirInfo = SystemPaths.TempFolderDirectoryInfo;
            long totalSize = 0;
            try
            {
                foreach (FileInfo fileInfo in dirInfo.GetFiles("*", SearchOption.AllDirectories))
                {
                    totalSize += fileInfo.Length;
                }
            }
            catch { }
            return totalSize;
        }
    }
}
