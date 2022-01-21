using System;

namespace RK_A5.Utilities
{
    public static class DateAgeUtility
    {
        public static uint CalAge(string date)
        {
            uint result = 0;
            DateTime dobParse = ParseDate(date);
            if (date != null && date != "" && DateTime.Compare(DateTime.MinValue, dobParse) != 0)
            {
                DateTime now = DateTime.Now;
                if (dobParse.Year < now.Year)
                    result = (uint)(now.Year - dobParse.Year);
            }

            return result;
        }

        public static DateTime ParseDate(string date)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(date, out result);
            return result;
        }

    }
}