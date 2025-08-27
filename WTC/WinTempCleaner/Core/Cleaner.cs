using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinTempCleaner.Configuration;

namespace WinTempCleaner.Core
{
    public static class Cleaner
    {
        public static long CleanUserTempFolder()
        {
            DirectoryInfo dirInfo = SystemPaths.TempFolderDirectoryInfo;

            long totalSize = 0;
            try
            {
                foreach (FileInfo file in dirInfo.GetFiles("*", SearchOption.AllDirectories))
                {
                    totalSize += file.Length;
                }
            }
            catch { }

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception)
                {

                }
            }
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                }
                catch (Exception)
                {

                }
            }
            return totalSize;
        }
    }
}
