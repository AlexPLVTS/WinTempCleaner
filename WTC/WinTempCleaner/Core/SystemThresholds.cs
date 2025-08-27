using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTempCleaner.Core
{
    public static class SystemThresholds
    {
        public const int WINDOWS_RED_BAR_PERCENTAGE = 10;

        public const int PROACTIVE_CLEANUP_MARGIN_PERCENTAGE = 1;

        public const int TRIGGER_PERCENTAGE = WINDOWS_RED_BAR_PERCENTAGE + PROACTIVE_CLEANUP_MARGIN_PERCENTAGE;
    }
}
