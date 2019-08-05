using System;

namespace Framework.Security
{
    public class Base64Encoding
    {
        /// <summary>
        /// 将字符串加密为Base64
        /// </summary>
        /// <param name="encode">编码</param>
        /// <param name="str">待加密字符串</param>
        /// <returns>加密成功，返回加密后字符串，失败则返回原字符串</returns>
        public static string EncodeBase64(System.Text.Encoding encode, string str)
        {
            byte[] bytes = encode.GetBytes(str);
            try
            {
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return str;
            }
        }
        public static string EncodeBase64(string str)
        {
            return EncodeBase64(System.Text.Encoding.UTF8, str);
        }
        /// <summary>
        /// 解密BASE64字符串
        /// </summary>
        /// <param name="encode"></param>
        /// <param name="base64Str"></param>
        /// <returns></returns>
        public static string DecodeBase64(System.Text.Encoding encode, string base64Str)
        {
            byte[] bytes = Convert.FromBase64String(base64Str);
            try
            {
                return encode.GetString(bytes);
            }
            catch
            {
                return base64Str;
            }
        }
        public static string DecodeBase64(string base64Str)
        {
            return DecodeBase64(System.Text.Encoding.UTF8, base64Str);
        }
    }
}
