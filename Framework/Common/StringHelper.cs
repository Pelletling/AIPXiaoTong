using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    public static class StringHelper
    {
        public static string TrimNewLine(this string str)
        {
            return str.Replace(Environment.NewLine, "").Trim();
        }

        /// <summary>
        /// 获取字符串中的第1个数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal GetFirstNumber(this string str)
        {
            decimal result = 0;
            if (!string.IsNullOrWhiteSpace(str))
            {
                Regex reg = new Regex(@"[-]?[0-9][0-9.]*");
                MatchCollection mc = reg.Matches(str);

                foreach (Match m in mc)
                {
                    result = Convert.ToDecimal(m.Value);
                    break;
                }
            }
            return result;
        }

        public static string ConvertUpper(this string money)
        {
            //将小写金额转换成大写金额           
            double MyNumber = Convert.ToDouble(money);
            String[] MyScale = { "分", "角", "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "兆", "拾", "佰", "仟" };
            String[] MyBase = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            String M = "";
            bool isPoint = false;
            if (money.IndexOf(".") != -1)
            {
                money = money.Remove(money.IndexOf("."), 1);
                isPoint = true;
            }
            for (int i = money.Length; i > 0; i--)
            {
                int MyData = Convert.ToInt16(money[money.Length - i].ToString());
                M += MyBase[MyData];
                if (isPoint == true)
                {
                    M += MyScale[i - 1];
                }
                else
                {
                    M += MyScale[i + 1];
                }
            }
            return M;
        }

        /// <summary>
        /// 从当前字符串的开头和结尾删除所有空白字符后剩余的字符串,字符串可为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToTrim(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            else
            {
                return str.Trim();
            }
        }

        //public static string ToTrim(this string str)
        //{
        //    if (string.IsNullOrWhiteSpace(str))
        //    {
        //        return str;
        //    }
        //    else
        //    {
        //        return str.Trim();
        //    }
        //}

        public static decimal ToDecimal(this string str)
        {
            decimal d = 0;
            Decimal.TryParse(str, out d);
            return d;
        }


        public static int ToInt(this Enum e)
        {
            return Convert.ToInt16(e);
        }

        public static int ToInt(this string str)
        {
            int i = 0;
            Int32.TryParse(str, out i);
            return i;
        }

        public static Dictionary<string, string> ToDictionary(this string str, bool isTrim = false)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var m in str.Split('&'))
            {
                var c = m.Split('=');

                if (isTrim && string.IsNullOrWhiteSpace(c[1]))
                {
                    continue;
                }

                dic.Add(c[0], c[1]);
            }

            return dic;
        }

        /// <summary>
        /// 转换成BASE64字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBase64(this string str)
        {
            var result = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(str));
            if (result.IndexOf("77u/") == 0)
            {
                result = result.Substring("77u/".Length);
            }
            return result;
        }

        /// <summary>
        /// 将BASE64字符转换成 string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FormBase64(this string str)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }



        /// <summary>
        /// 校验银行卡号规则
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBankCard(this string str)
        {
            List<int> unevenNumberList = new List<int>();//奇数位
            List<int> EvenNumberList = new List<int>();//偶数位

            for (int i = 0; i < str.Length; i++)
            {
                if (!str[str.Length - i - 1].ToString().IsNumeric())
                    throw new Exception("包含非法字符.");

                var number = str[str.Length - i - 1].ToString().ToInt();

                if (i % 2 == 0)
                {
                    unevenNumberList.Add(number);
                }
                else
                {
                    //偶数位乘以2（若乘积大于9就要减去9）
                    number = number * 2;
                    if (number > 9)
                    {
                        number = number - 9;
                    }

                    EvenNumberList.Add(number);
                }
            }

            if ((unevenNumberList.Sum() + EvenNumberList.Sum()) % 10 == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 替换字符串，且头尾去空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceStringTrim(this string str, string relpaceString)
        {
            string value = str ?? "";
            value = string.IsNullOrWhiteSpace(relpaceString) ? value : value.Replace(relpaceString, "");
            return value.ToTrim();
        }

        /// <summary>
        /// 验证身份证（仅限18位）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIDNumber(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            else
            {
                str = str.ToTrim();
            }

            if (str.Length != 18)
                return false;

            List<int> list = new List<int> { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };

            List<string> remainderList = new List<string>() { "1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2" };

            int total = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                int m = Convert.ToInt32(str[i].ToString());

                total += m * list[i];
            }

            int remainder = total % 11;

            if (str[17].ToString().ToUpper() == remainderList[remainder])
                return true;

            return false;
        }

        /// <summary>
        /// 获取身份证岁数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetIDNumberAge(string number)
        {
            int year = Convert.ToInt16(number.Substring(6, 4));

            int age = DateTime.Now.Year - year;

            return age;
        }

        /// <summary>
        /// 获得字符串中开始和结束字符串中间得值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="s">开始</param>
        /// <param name="e">结束</param>
        /// <returns></returns> 
        public static string GetValue(this string str, string s, string e)
        {
            Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(str).Value;
        }

    }
}
