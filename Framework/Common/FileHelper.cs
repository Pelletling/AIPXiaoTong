using System;
using System.IO;
using System.Web;
using System.Text;

namespace Framework.Common
{
    public static class FileHelper
    {
        private readonly static object LockWirteLine = new object();
        public static void WirteLine(string message, string path = "")
        {
            lock (LockWirteLine)
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + "/logs.txt";
                }
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    //开始写入
                    sw.WriteLine(DateTime.Now.ToString() + "：" + message);
                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                }
            }
        }

        public static void Wirte(string message, string path = "", bool isAppend = true)
        {
            using (StreamWriter sw = new StreamWriter(path, isAppend, Encoding.UTF8))
            {
                //开始写入
                sw.WriteLine(message);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
            }
        }

        public static void WirteCover(string message, string path)
        {

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                //开始写入
                sw.Write(message);

                //清空缓冲区
                sw.Flush();

                //关闭流
                sw.Close();
            }
        }


        public static void Move(string formPath, string toPath, bool overwrite = false)
        {
            if (formPath == toPath)
                return;

            if (overwrite == true && File.Exists(toPath))
            {
                File.Delete(toPath);
            }

            File.Move(formPath, toPath);

        }

        public static string Read(string path, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            using (StreamReader rw = new StreamReader(path, encoding))
            {
                string data = rw.ReadToEnd();
                rw.Close();
                rw.Dispose();
                return data;
            }
        }

        public static void WriteFile(this MemoryStream ms, string Path)
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                fs = new FileStream(Path, FileMode.Create);
                bw = new BinaryWriter(fs);
                bw.Write(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ms != null) ms.Close();
                if (bw != null) bw.Close();
                if (fs != null) fs.Close();
            }
        }

        public static void WriteFile(this Stream stream, string path)
        {
           
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(StreamToBytes(stream));
                sw.Close();
            }
        }

        /// <summary> 
        /// 将 Stream 转成 byte[] 
        /// </summary> 
        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            // 设置当前流的位置为流的开始 
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary> 
        /// 将 byte[] 转成 Stream 
        /// </summary> 
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// 获取文件后缀
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string FileExt(this string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf('.') + 1);
        }

        /// <summary>
        /// 将文件转成base64
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToBase64(string path)
        {
            string base64 = "";

            using (FileStream filestream = new FileStream(path, FileMode.Open))
            {
                byte[] bt = new byte[filestream.Length];

                //调用read读取方法
                filestream.Read(bt, 0, bt.Length);

                base64 = Convert.ToBase64String(bt);

                filestream.Close();
            }

            return base64;
        }
    }
}
