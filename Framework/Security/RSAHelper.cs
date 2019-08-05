﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Framework.Security
{
    public class RSAHelper
    {
        /// <summary>    
        /// RSA私钥格式转换，java->.net
        /// </summary>    
        /// <param name="privateKey">java生成的RSA私钥</param>    
        /// <returns></returns>    
        public static string RSAPrivateKeyJava2DotNet(string privateKey)
        {
            return RSAConvert.RSA.RSAPrivateKeyJava2DotNet(privateKey);
        }

        /// <summary>    
        /// RSA私钥格式转换，.net->java    
        /// </summary>    
        /// <param name="privateKey">.net生成的私钥</param>    
        /// <returns></returns>    
        public static string RSAPrivateKeyDotNet2Java(string privateKey)
        {
            return RSAConvert.RSA.RSAPrivateKeyDotNet2Java(privateKey);
        }


        /// <summary>    
        /// RSA公钥格式转换，java->.net    
        /// </summary>    
        /// <param name="publicKey">java生成的公钥</param>    
        /// <returns></returns>    
        public static string RSAPublicKeyJava2DotNet(string publicKey)
        {
            return RSAConvert.RSA.RSAPublicKeyJava2DotNet(publicKey);
        }

        /// <summary>    
        /// RSA公钥格式转换，.net->java    
        /// </summary>    
        /// <param name="publicKey">.net生成的公钥</param>    
        /// <returns></returns>    
        public static string RSAPublicKeyDotNet2Java(string publicKey)
        {
            return RSAConvert.RSA.RSAPublicKeyDotNet2Java(publicKey);
        }

        /// <summary>
        /// 根据私钥加密
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string EncryptByPrivateKey(string privateKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            rsa.FromXmlString(privateKey);

            var sign = Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(content), false));

            return sign;
        }

       

        /// <summary>
        /// 根据JAVA（SHA1WithRSA）加密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="privateKey"></param>
        /// <param name="input_charset"></param>
        /// <returns></returns>
        public static string SHA1WithRSA(string content, string privateKey, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;

            byte[] Data = encoding.GetBytes(content);

            RSACryptoServiceProvider rsa = RSAExt.DecodePemPrivateKey(privateKey);

            SHA1 sh = new SHA1CryptoServiceProvider();

            byte[] signData = rsa.SignData(Data, sh);

            return Convert.ToBase64String(signData);
        }

        /// <summary>  
        /// 根据JAVA（SHA1WithRSA）验签  
        /// </summary>  
        /// <param name="content">待验签字符串</param>  
        /// <param name="signedString">签名</param>  
        /// <param name="publicKey">公钥</param>  
        /// <param name="input_charset">编码格式</param>  
        /// <returns>true(通过),false(不通过)</returns>  
        public static bool SHA1WithRSAVerify(string content, string signedString, string publicKey, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;

            bool result = false;

            byte[] Data = encoding.GetBytes(content);

            byte[] data = Convert.FromBase64String(signedString);

            RSAParameters paraPub = RSAExt.ConvertFromPublicKey(publicKey);

            RSACryptoServiceProvider rsaPub = new RSACryptoServiceProvider();

            rsaPub.ImportParameters(paraPub);

            SHA1 sh = new SHA1CryptoServiceProvider();

            result = rsaPub.VerifyData(Data, sh, data);

            return result;
        }

        /// <summary>
        /// RSA分段加密;用于对超长字符串加密
        /// </summary>
        /// <param name="toEncryptString">需要进行加密的字符串</param>
        /// <param name="publickKey">公钥</param>
        /// <returns>加密后的密文</returns>
        public static byte[] SectionEncrypt(string toEncryptString, string publickKey)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            byte[] dataToEncrypt = System.Text.Encoding.UTF8.GetBytes(toEncryptString);

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            RSA.FromXmlString(publickKey);

            int MaxBlockSize = RSA.KeySize / 8 - 11;

            if (dataToEncrypt.Length <= MaxBlockSize)
            {
                byte[] encrytedData;

                encrytedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

                return encrytedData;
            }

            MemoryStream plaiStream = new MemoryStream(dataToEncrypt);

            MemoryStream CrypStream = new MemoryStream();

            Byte[] Buffer = new Byte[MaxBlockSize];

            int BlockSize = plaiStream.Read(Buffer, 0, MaxBlockSize);

            while (BlockSize > 0)
            {
                Byte[] ToEncrypt = new Byte[BlockSize];
                Array.Copy(Buffer, 0, ToEncrypt, 0, BlockSize);

                Byte[] Cryptograph = RSAEncrypt(ToEncrypt, RSA.ExportParameters(false), false);
                CrypStream.Write(Cryptograph, 0, Cryptograph.Length);
                BlockSize = plaiStream.Read(Buffer, 0, MaxBlockSize);

            }
            return CrypStream.ToArray();
        }

        /// <summary>
        /// RSA分段解密;用于对超长字符串解密
        /// </summary>
        /// <param name="toEncryptString">需要进行解密的字符串</param>
        /// <param name="publickKey">私钥</param>
        /// <returns>解密后的明文</returns>
        public static byte[] SectionDecrypt(byte[] toDecryptByte, string privateKey)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(privateKey);
            ;
            byte[] CiphertextData = toDecryptByte;

            int MaxBlockSize = RSA.KeySize / 8;

            if (CiphertextData.Length <= MaxBlockSize)
            {
                byte[] decryptedData;

                decryptedData = RSADecrypt(CiphertextData, RSA.ExportParameters(true), false);

                return decryptedData;
            }

            MemoryStream CrypStream = new MemoryStream(CiphertextData);

            MemoryStream PlaiStream = new MemoryStream();

            Byte[] Buffer = new Byte[MaxBlockSize];

            int BlockSize = CrypStream.Read(Buffer, 0, MaxBlockSize);

            while (BlockSize > 0)
            {
                Byte[] ToDecrypt = new Byte[BlockSize];
                Array.Copy(Buffer, 0, ToDecrypt, 0, BlockSize);

                Byte[] Plaintext = RSADecrypt(ToDecrypt, RSA.ExportParameters(true), false);
                PlaiStream.Write(Plaintext, 0, Plaintext.Length);

                BlockSize = CrypStream.Read(Buffer, 0, MaxBlockSize);
            }
            return PlaiStream.ToArray();
        }

        private static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            RSA.ImportParameters(RSAKeyInfo);

            return RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
        }

        private static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            RSA.ImportParameters(RSAKeyInfo);

            return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
        }

        /// <summary>
        /// 生产RSA公私钥 keysize=2048  [0]为privatekey [1]为publickey
        /// </summary>
        /// <returns></returns>
        public static string[] GenerateKeys()
        {
            string[] sKeys = new String[2];
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            sKeys[0] = rsa.ToXmlString(true);
            sKeys[1] = rsa.ToXmlString(false);
            return sKeys;
        }

    }
}