using System;
namespace Framework.Common
{
    /// <summary>
    /// DateTim和TimpStamp互转类
    /// </summary>
    /// public static class DateTimeHelper
    public static class DateTimeHelper
    {
        /// <summary>
        /// 普通时间转换成timestamp格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>

        public static long ToTimeStamp(this DateTime dt)
        {
            double timeStamp = (dt - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;

            return Convert.ToInt64(timeStamp);
        }

        public static long ToTimeStampLocal(this DateTime dt)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            double timeStamp = (dt - startTime).TotalSeconds;

            return Convert.ToInt64(timeStamp);
        }

        public static long ToLocalTimeTotalMilliseconds(this DateTime dt)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            double timeStamp = (dt - startTime).TotalMilliseconds;

            return Convert.ToInt64(timeStamp);
        }

        /// <summary>
        /// 将timestamp转换成标准时间格式
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timeStamp)
        {
            DateTime dt = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(timeStamp);
            return dt;
        }
        /// <summary>
        /// 将timestamp转换成指定格式的时间字符串
        /// </summary>
        /// <param name="timeStamp">long型时间</param>
        /// <param name="format">格式化字符</param>
        /// <returns></returns>
        public static string ToDateTime(this long timeStamp, string format)
        {
            DateTime dt = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(timeStamp);
            return dt.ToString(format);
        }
        /// <summary>
        /// 将timestamp转换成指定格式的时间字符串
        /// </summary>
        /// <param name="timeStamp">long型时间</param>
        /// <param name="format">格式化字符串</param>
        /// <param name="provider">格式提供者</param>
        /// <returns></returns>
        public static string ToDateTime(this long timeStamp, string format, IFormatProvider provider)
        {
            DateTime dt = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(timeStamp);
            return dt.ToString(format, provider);
        }
        /// <summary>
        /// 扩展方法 判断两个日期是否属于同一周
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsInTheSameWeek(this DateTime left, DateTime right)
        {

            return left.GetWeekStartDate().HasTheSameDataParts(right.GetWeekStartDate());

        }
        /// <summary>
        /// 扩展方法 返回两个日期是否一致
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool HasTheSameDataParts(this DateTime left, DateTime right)
        {

            return left.Day == right.Day && left.Month == right.Month && left.Year == right.Year;

        }
        /// <summary>
        /// 扩展方法 返回时间所属周的开始日期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetWeekStartDate(this DateTime date)
        {
            DateTime start;
            try
            {
                start = date.AddDays(-1 * (int)date.DayOfWeek);
            }
            catch (ArgumentOutOfRangeException)//如果DateTime为最小值，可能引发此异常，对此我们返回DateTime.Min
            {
                start = DateTime.MinValue;
            }
            return start;
        }

        /// <summary>
        /// 获取当前时间最后1毫秒，例如:  2015-01-01 23:59:59.999
        /// </summary>
        /// <param name="date">2015-01-01</param>
        /// <returns></returns>
        public static string ToDateLastMilliSecond(this string date)
        {
            return Convert.ToDateTime(date).ToString("yyyy-MM-dd 23:59:59.999");
        }


        public static DateTime? ToDateTimeOrNull(this string date)
        {
            if (!string.IsNullOrWhiteSpace(date))
            {
                return Convert.ToDateTime(date);
            }
            else
            {
                return null;
            }
        }

        public static DateTime? ToDateTimeOrNull(this string date, string format)
        {
            if (!string.IsNullOrWhiteSpace(date))
            {
                return DateTime.ParseExact(date, format, System.Globalization.CultureInfo.CurrentCulture);
            }
            else
            {
                return null;
            }
        }

        public static DateTime ToDateTime(this string date, string format)
        {
            if (!string.IsNullOrWhiteSpace(date))
            {
                return DateTime.ParseExact(date, format, System.Globalization.CultureInfo.CurrentCulture);
            }
            else
            {
                return new DateTime(1970, 1, 1);
            }
        }

        public static string ToShortDate(this DateTime date, string Format = "yyyy-MM-dd")
        {
            return date != null ? Convert.ToDateTime(date).ToString(Format) : "";
        }

        public static string ToLongDate(this DateTime date, string Format = "yyyy-MM-dd HH:mm:ss")
        {
            return date != null ? Convert.ToDateTime(date).ToString(Format) : "";
        }

        public static string ToShortDate(this DateTime? date)
        {
            return date != null ? Convert.ToDateTime(date).ToString("yyyy-MM-dd") : "";
        }

        public static string ToLongDate(this DateTime date)
        {
            return Convert.ToDateTime(date).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToLongDate(this DateTime? date)
        {
            return date != null ? Convert.ToDateTime(date).ToString("yyyy-MM-dd HH:mm:ss") : "";
        }

        public static DateTime ToDateTime(this DateTime? date)
        {
            return date == null ? new DateTime(1970, 1, 1) : Convert.ToDateTime(date);
        }

        public static string ToShortDateString(this DateTime? date)
        {
            return date != null ? Convert.ToDateTime(date).ToString("yyyy-MM-dd") : "";
        }
        public static string ToLongDateString(this DateTime? date)
        {
            return date != null ? Convert.ToDateTime(date).ToString("yyyy-MM-dd HH:mm:ss") : "";
        }
        public static string ToDateime2(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
        }

        /// <summary>
        /// 计算两个时间的间隔的月数
        /// </summary>
        /// <param name="sourceDate"></param>
        /// <param name="compareDate"></param>
        /// <returns></returns>
        public static int DifferMonths(this DateTime sourceDate, DateTime compareDate)
        {
            int Month = (sourceDate.Year - compareDate.Year) * 12 + (sourceDate.Month - compareDate.Month);

            return Month;
        }
    }
}

