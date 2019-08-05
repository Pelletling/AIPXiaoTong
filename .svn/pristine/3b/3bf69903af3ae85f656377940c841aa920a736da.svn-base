using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Framework.Security
{
    public class Crypt
    {
        public static string MD5(string str, bool cut16 = false)
        {
            if (cut16)
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(0, 16);
            }
            else
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }
        }
        public static string SHA1(string str, bool cut16 = false)
        {
            if (cut16)
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1").Substring(0, 16);
            }
            else
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1");
            }
        }

        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="str"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string str, string sKey)
        {
            var des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(str);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            var ms = new System.IO.MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            var ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="str"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string str, string sKey)
        {
            var des = new DESCryptoServiceProvider();
            int len;
            len = str.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(str.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            var ms = new System.IO.MemoryStream();
            var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        /// <summary>
        /// 使用私钥进行RSA加密(通联通专用)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="certPath"></param>
        /// <returns></returns>
        public static string RSAEncryptByPrivateKeyTLT(string value, string certPath, string password)
        {
            string sign = "";
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] msg = sha1.ComputeHash(Encoding.GetEncoding("GBK").GetBytes(value));

            RSAPKCS1SignatureFormatter signe = new RSAPKCS1SignatureFormatter();

            X509Certificate2 x509 = new X509Certificate2(certPath, password);

            signe.SetKey(x509.PrivateKey);
            signe.SetHashAlgorithm("SHA1");
            sign = ToHex(signe.CreateSignature(msg));

            return sign;
        }

        /// <summary>
        /// 使用私钥进行RSA加密,并返回Base64
        /// </summary>
        /// <param name="value"></param>
        /// <param name="certPath"></param>
        /// <returns></returns>
        public static string RSAEncryptByPrivateKey(string value, string certPath, string password)
        {
            string sign = "";
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] msg = sha1.ComputeHash(Encoding.UTF8.GetBytes(value));

            RSAPKCS1SignatureFormatter signe = new RSAPKCS1SignatureFormatter();

            X509Certificate2 x509 = new X509Certificate2(certPath, password);

            signe.SetKey(x509.PrivateKey);
            signe.SetHashAlgorithm("SHA1");
            sign = Convert.ToBase64String(signe.CreateSignature(msg));

            return sign;
        }


        private static string ToHex(byte[] ba)
        {
            if (ba == null) return "";
            char[]
                buf = new char[ba.Length * 2];

            int p = 0;
            foreach (byte b in ba)
            {
                buf[p++] = hexChars[b >> 4];
                buf[p++] = hexChars[b & 0x0f];
            }
            return new string(buf);
        }

        private static char[] hexChars = "0123456789abcdef".ToCharArray();

        /// <summary>
        /// 验签
        /// </summary>
        /// <param name="str"></param>
        /// <param name="signMsg"></param>
        /// <param name="certPath"></param>
        /// <returns></returns>
        public static bool RSADecrypt(String str, String signMsg, String certPath)
        {
            //base64解码签名串
            Byte[] signMsgBytes = Convert.FromBase64String(signMsg);

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //读取x509证书
            X509Certificate2 x509 = new X509Certificate2();
            x509.Import(certPath);

            //灌注到rsa
            rsa.FromXmlString(x509.PublicKey.Key.ToXmlString(false));
            bool verifyResult = rsa.VerifyData(System.Text.Encoding.UTF8.GetBytes(str), "SHA1", signMsgBytes);

            return verifyResult;
        }

        /// <summary>
        /// 验签
        /// </summary>
        /// <param name="str"></param>
        /// <param name="signMsg"></param>
        /// <param name="certPath"></param>
        /// <returns></returns>
        public static bool RSADecryptByPublicKey(String str, String signMsg, String certPath)
        {

            Byte[] signMsgBytes = HexStringToByteArray(signMsg);

            //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //读取x509证书
            X509Certificate2 x509 = new X509Certificate2();
            x509.Import(certPath);

            //灌注到rsa
            //rsa.FromXmlString(x509.PublicKey.Key.ToXmlString(false));
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)x509.PublicKey.Key;

            bool verifyResult = rsa.VerifyData(System.Text.Encoding.GetEncoding("GBK").GetBytes(str), "SHA1", signMsgBytes);

            return verifyResult;
        }

        //private static byte[] ToBytes(string hexStr)
        //{
        //    if ((hexStr.Length & 1) != 0)
        //        return null;
        //    byte[] buf = new byte[hexStr.Length / 2];
        //    for (int i = 0; i < hexStr.Length; i += 2)
        //    {
        //        byte h = GetHexValue(hexStr[i]);
        //        byte l = GetHexValue(hexStr[i + 1]);
        //        if (h == 255 || l == 255)
        //            return null;
        //        buf[i >> 1] = (byte)((h << 4) | l);
        //    }
        //    return buf;
        //}

        //private static byte GetHexValue(char c)
        //{
        //    if (c >= '0' && c <= '9')
        //        return (byte)(c - '0');
        //    else if (c >= 'a' && c <= 'f')
        //        return (byte)(c - 'a' + 10);
        //    else
        //        return 255;
        //}

        /// <summary>
        /// 十六进制转Byte[]
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace("   ", " ");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        public static bool RSADecryptByPublicKey1(String str, String signMsg, String certPath)
        {

            Byte[] signMsgBytes = System.Text.Encoding.UTF8.GetBytes(signMsg);

            //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //读取x509证书
            X509Certificate2 x509 = new X509Certificate2();
            x509.Import(certPath);

            //灌注到rsa
            //rsa.FromXmlString(x509.PublicKey.Key.ToXmlString(false));
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)x509.PublicKey.Key;

            bool verifyResult = rsa.VerifyData(System.Text.Encoding.GetEncoding("GBK").GetBytes(str), "SHA1", signMsgBytes);

            return verifyResult;
        }

        /// <summary>
        /// 使用公钥进行RSA加密
        /// </summary>
        /// <param name="value"></param>
        /// <param name="certPath"></param>
        /// <returns></returns>
        public static string RSAEncryptByPublicKey(string content, string certPath)
        {
            //读取x509证书
            X509Certificate2 x509 = new X509Certificate2();
            x509.Import(certPath);

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(x509.PublicKey.Key.ToXmlString(false));
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);
            return Convert.ToBase64String(cipherbytes);

        }


        ///  des加密
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串。</param>
        /// <param name="sKey">密钥，且必须为8位。默认公钥加密字符串defaultKey</param>
        /// <returns>以Base64格式返回的加密字符串。</returns>
        public static string DESEncrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.GetEncoding("UTF-8").GetBytes(pToEncrypt);

            //建立加密对象的密钥和偏移量    
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法    
            //使得输入密码必须输入英文文本    
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            string str = Convert.ToBase64String(ms.ToArray());

            return str.ToString();
        }

    }
}
