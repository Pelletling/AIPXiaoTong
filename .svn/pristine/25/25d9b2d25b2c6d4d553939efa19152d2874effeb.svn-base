using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
   public class ZipIonicHelper
    {
        /// <summary>
        /// 从 zip 文件中解压出一个文件  
        /// </summary>
        /// <param name="ZipName"></param>
        /// <param name="ToPath"></param>
        /// <param name="FileName"></param>
        /// <param name="Password"></param>
        public static void ExeSingleDeComp(string ZipName, string ToPath, string FileName,string Password="")
        {
            using (ZipFile zip = ZipFile.Read(ZipName))
            {
                if (!string.IsNullOrWhiteSpace(Password))
                {
                    zip.Password = Password;// 密码解压  
                }
                                        
                //Extract 解压 zip 文件包的方法，参数是保存解压后文件的路基  
                zip[FileName].Extract(ToPath);
            }
        }
        
        /// <summary>
        /// 从 zip 文件中解压全部文件  
        /// </summary>
        /// <param name="ZipName">压缩文件</param>
        /// <param name="ToPath">解压目录</param>
        /// <param name="Password">密码，没有则不填</param>
        public static void ExeAllDeComp(string ZipName,string ToPath, string Password = "")
        {
            using (ZipFile zip = ZipFile.Read(ZipName))
            {
                if (!string.IsNullOrWhiteSpace(Password))
                {
                    zip.Password = Password;// 密码解压  
                }

                foreach (ZipEntry entry in zip)
                {
                    //Extract 解压 zip 文件包的方法，参数是保存解压后文件的路基  
                    entry.Extract(ToPath,ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
}
