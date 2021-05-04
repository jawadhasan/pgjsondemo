using System;

namespace LicenseHelper
{
    public static class LicenseDateTimeConverter
    {
        public static uint DateTimeToJulianDate(DateTime date)
        {
            TimeSpan ts = date - new DateTime(2000, 1, 1);
            return (uint)ts.TotalMinutes;
        }

        public static DateTime JulianDateToDateTime(uint julianDate)
        {
            DateTime dtOut = new DateTime(2000, 1, 1);
            dtOut = dtOut.AddMinutes(julianDate);
            return dtOut;
        }


        public static DateTime JulianDateStringToDateTime(string julianDateString)
        {
            var uintJulianDate = uint.Parse(julianDateString);
            return JulianDateToDateTime(uintJulianDate);
        }
    }
}
