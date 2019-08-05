using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;

namespace Framework.Common
{
    public static class ImageHelper
    {
        /// <summary>
        /// 按比例缩小图片，自动计算宽度或高度
        /// </summary>
        /// <param name="strOldPic">源图文件名(包括路径)</param>
        /// <param name="strNewPic">缩小后保存为文件名(包括路径)</param>
        /// <param name="heightOrWidth">缩小至高度或宽度</param>
        public static bool Resize(string strOldPic, string strNewPic, int heightOrWidth)
        {
            bool bRet = false;
            int height = 0;
            int width = 0;

            using (Bitmap objPic = new System.Drawing.Bitmap(strOldPic))
            {
                if (heightOrWidth > 0 && (objPic.Width > heightOrWidth || objPic.Height > heightOrWidth))
                {
                    if (objPic.Height > objPic.Width)
                    {
                        width = Convert.ToInt32((heightOrWidth * 1.0 / objPic.Height) * objPic.Width);
                        height = heightOrWidth;
                    }
                    else
                    {
                        width = heightOrWidth;
                        height = Convert.ToInt32((heightOrWidth * 1.0 / objPic.Width) * objPic.Height);
                    }

                    using (Bitmap objNewPic = new Bitmap(objPic, width, height))
                    {
                        objNewPic.Save(strNewPic, ImageFormat.Jpeg);
                        bRet = true;
                    }
                }

            }

            return bRet;
        }

        public static string UploadImage(string fileName, string path = "/temp/")
        {
            var file = HttpContext.Current.Request.Files[0];
            var serverPath = HttpContext.Current.Server.MapPath(path);
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory(serverPath);
            }
            string FilePath = serverPath + fileName;
            file.SaveAs(FilePath);

            return FilePath;
        }

        public static string Resize(string fileName, int heightOrWidth, string path = "/temp/")
        {
            string tempName = DateTime.Now.ToString("yyyyMMddHHmmss_") + Guid.NewGuid().ToString() + ".jpg";
            var filePath = UploadImage(tempName, path);

            var smallPath = HttpContext.Current.Server.MapPath(path) + fileName;

            var bRet = Resize(filePath, smallPath, heightOrWidth);

            return bRet ? path + fileName : path + tempName;
        }

        public static void Base64StringToImage(string Path, string Base64String)
        {
            using (FileStream fs = System.IO.File.Create(Path))
            {
                byte[] bytes = Convert.FromBase64String(Base64String);

                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }

        }

        public static bool IsBase64(string data)
        {
            try
            {
                Convert.FromBase64String(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 将图片数据转换为Base64字符串
        /// </summary>
        public static string ToBase64(string path)
        {
            using (MemoryStream ms1 = new MemoryStream())
            {
                Bitmap bmp1 = new Bitmap(path);
                bmp1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr1 = new byte[ms1.Length];
                ms1.Position = 0;
                ms1.Read(arr1, 0, (int)ms1.Length);
                bmp1.Dispose();
                ms1.Close();
                return Convert.ToBase64String(arr1);
            }
        }

        /// <summary>
        /// 将图片数据转换为Base64字符串
        /// </summary>
        public static string ToBase64(string path, ImageFormat format)
        {
            using (MemoryStream ms1 = new MemoryStream())
            {
                Bitmap bmp1 = new Bitmap(path);
                bmp1.Save(ms1, format);
                byte[] arr1 = new byte[ms1.Length];
                ms1.Position = 0;
                ms1.Read(arr1, 0, (int)ms1.Length);
                bmp1.Dispose();
                ms1.Close();
                return Convert.ToBase64String(arr1);
            }
        }
    }
}
