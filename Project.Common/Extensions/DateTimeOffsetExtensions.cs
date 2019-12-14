using System;
using DNTPersianUtils.Core;

namespace Project.Common.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset IranStandardTimeNow(this DateTimeOffset dateTimeOffset)
        {
            return DateTimeOffset.Now.ToIranTimeZoneDateTimeOffset();
        }

        public static string ToLtrDateTime(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.Date.Year + "-" + dateTimeOffset.Date.Month.ToString("00") + "-" + dateTimeOffset.Date.Day.ToString("00");
        }

        public static string ToLtrMiladiDateTime(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.Year + "/" + dateTimeOffset.Month + "/" + dateTimeOffset.Day;
        }

        public static string ToLtrDateTime(this DateTimeOffset? dateTimeOffset)
        {
            if (!dateTimeOffset.HasValue)
            {
                return "";
            }
            return dateTimeOffset.Value.Date.Year + "-" + dateTimeOffset.Value.Date.Month.ToString("00") + "-" + dateTimeOffset.Value.Date.Day.ToString("00");
        }
    }
}