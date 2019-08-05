using System;
using System.Collections.Generic;

namespace Framework.Common
{
    public static class NumeralHelper
    {
        public static long ToLong(this string str)
        {
            if (str.IsInt())
            {
                return Convert.ToInt64(str);
            }
            else
            {
                return 0;
            }
        }

        public static long? ToLongOrNull(this string str)
        {
            if (str.IsInt())
            {
                return Convert.ToInt64(str);
            }
            else
            {
                return null;
            }
        }

        public static List<long?> ToLongList(this string value, char c = ',')
        {
            List<long?> list = new List<long?>();
            if (!string.IsNullOrWhiteSpace(value))
            {
                foreach (var s in value.Split(c))
                {
                    list.Add(s.ToLongOrNull());
                }
            }
            return list;
        }

        public static IList<long> SplitToLong(this string value, char c = ',')
        {
            return Array.ConvertAll<string, long>(value.Split(c), s => Int64.Parse(s));
        }

        public static string ToMoney(this decimal d, int length = 2)
        {
            return d.ToString("N" + length.ToString());
        }

        public static string ToEmpty(this decimal d, int length = 2)
        {
            if (d == 0)
                return "";

            return d.ToString("N" + length.ToString());
        }

        public static int ToInt(this int? i)
        {
            return i != null ? Convert.ToInt32(i) : 0;
        }

        public static string ToEmpty(this int i)
        {
            return i != 0 ? i.ToString() : "";
        }

        public static decimal ToDecimal(this decimal? d)
        {
            return d != null ? Convert.ToDecimal(d) : 0;
        }

        public static long ToLong(this long? l)
        {
            return l != null ? Convert.ToInt64(l) : 0;
        }

        public static decimal ToDecimal(this double? d)
        {
            return d != null ? Convert.ToDecimal(d) : 0;
        }

        public static decimal ToDecimal(this double d)
        {
            return Convert.ToDecimal(d);
        }

        /// <summary>
        /// 保存2位小数，且不四舍五入
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal NotRound2Dec(decimal d)
        {
            return (Math.Truncate(d * 100) / 100).ToString("N2").ToDecimal();
        }
    }
}
