using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTempCleaner.Configuration
{
    public static class ApplicationStorage
    {
        public static string AppDataFolder { get; }
        public static string StatsFilePath { get; }

        static ApplicationStorage()
        {
            string roamingFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            AppDataFolder = Path.Combine(roamingFolder, "WinTempCleaner");

            Directory.CreateDirectory(AppDataFolder);

            StatsFilePath = Path.Combine(AppDataFolder, "stats.json");
        }
    }
}
