using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WinTempCleaner.Utils
{
    public static class FormattingHelper
    {
        private const long BytesInKilobyte = 1024;
        private const long BytesInMegabyte = BytesInKilobyte * 1024;
        private const long BytesInGigabyte = BytesInMegabyte * 1024;
        public static string BytesToHumanReadableString(long bytes)
        {
            double gigabytes = bytes / (double)BytesInGigabyte;

            if (gigabytes >= 1.0)
            {
                return gigabytes.ToString("F3", CultureInfo.InvariantCulture) + " GB";
            }

            double megabytes = bytes / (double)BytesInMegabyte;
            return $"{megabytes:F0} MB";
        }
    }
}
