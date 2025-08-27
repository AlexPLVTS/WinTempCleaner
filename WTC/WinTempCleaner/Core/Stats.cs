using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinTempCleaner.Configuration;

namespace WinTempCleaner.Core
{
    public class Stats
    {
        public int TimesCleaned { get; set; } = 0;
        public long TotalBytesFreed { get; set; } = 0;

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(ApplicationStorage.StatsFilePath, json);
        }

        public static Stats Load()
        {
            if (!File.Exists(ApplicationStorage.StatsFilePath))
            {
                return new Stats();
            }

            string json = File.ReadAllText(ApplicationStorage.StatsFilePath);
            return JsonConvert.DeserializeObject<Stats>(json);
        }
        public static void RecordCleanup(long bytesFreed)
        {
            if (bytesFreed <= 0)
            {
                return;
            }
            Stats currentStats = Stats.Load();
            currentStats.TimesCleaned++;
            currentStats.TotalBytesFreed += bytesFreed;
            currentStats.Save();
        }
    }
}
