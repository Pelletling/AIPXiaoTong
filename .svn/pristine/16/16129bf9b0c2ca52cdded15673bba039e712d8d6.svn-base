using Framework.Collections;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml;

namespace Framework.Configuration
{
    public static class WebConfig
    {
        /// <summary>
        /// 获取指定appsetting配置节信息
        /// </summary>
        /// <param name="key">appsetting配置名</param>
        /// <returns>返回appsetting配置值</returns>
        public static string GetAppSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 获取指定appsetting配置节信息
        /// </summary>
        /// <param name="key">appsetting配置名</param>
        /// <returns>返回appsetting配置值</returns>
        public static int GetAppSettingInt(string key)
        {
            int i = 0;
            Int32.TryParse(System.Configuration.ConfigurationManager.AppSettings[key],out i);
            return i;
        }

        /// <summary>
        /// 获取指定appsetting配置节信息
        /// </summary>
        /// <param name="index">appsetting配置索引</param>
        /// <returns>返回appsetting配置值</returns>
        public static string GetAppSetting(int index)
        {
            return System.Configuration.ConfigurationManager.AppSettings[index];
        }
        /// <summary>
        /// 获取指定数据库连接字符串
        /// </summary>
        /// <param name="key">数据库连接名</param>
        /// <returns>返回数据库连接字符串</returns>
        public static string GetConnectionString(string key)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
        /// <summary>
        /// 获取指定数据库连接字符串
        /// </summary>
        /// <param name="key">数据库连接索引</param>
        /// <returns>返回数据库连接字符串</returns>
        public static string GetConnectionString(int index)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[index].ConnectionString;
        }
        /// <summary>
        /// 获取指定配置节集合
        /// </summary>
        /// <param name="sectionPath">配置节路径</param>
        /// <returns>返回配置节集合</returns>

        public static NameValueCollection GetSection(string sectionPath)
        {
            return (NameValueCollection)System.Configuration.ConfigurationManager.GetSection(sectionPath);
        }

        /// <summary>
        /// 获取指定配置节指定配置的值
        /// </summary>
        /// <param name="sectionPath">配置节路径</param>
        /// <param name="sectionPath">配置名称</param>
        /// <returns>返回配置节集合</returns>
        public static string GetSectionValue(string sectionPath, string key)
        {
            return GetSection(sectionPath)[key];
        }
        /// <summary>
        /// 获取指定配置节指定配置的值
        /// </summary>
        /// <param name="sectionPath">配置节路径</param>
        /// <param name="sectionPath">配置索引</param>
        /// <returns>返回配置节集合</returns>
        public static string GetSectionValue(string sectionPath, int index)
        {
            return GetSection(sectionPath)[index];
        }
        public static void SaveAppsetting(string key, string value)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            string configPath = System.Web.HttpContext.Current.Server.MapPath("~/Web.config");
            objXmlDoc.Load(configPath);
            XmlElement node = (XmlElement)objXmlDoc.SelectSingleNode("/configuration/appSettings/add[@key='" + key + "']");
            node.SetAttribute("value", value);
            objXmlDoc.Save(configPath);
        }
        public static void SaveAppsettings(IList<NameValue> namevalues)
        {
            if (namevalues != null)
            {
                XmlDocument objXmlDoc = new XmlDocument();
                string configPath = System.Web.HttpContext.Current.Server.MapPath("~/Web.config");
                objXmlDoc.Load(configPath);

                foreach (var n in namevalues)
                {
                    XmlElement node = (XmlElement)objXmlDoc.SelectSingleNode("/configuration/appSettings/add[@key='" + n.Name + "']");
                    if (node != null)
                        node.SetAttribute("value", n.Value);
                    else
                    {
                        var app = objXmlDoc.SelectSingleNode("/configuration/appSettings");
                        if (app != null)
                        {
                            XmlElement addElement = objXmlDoc.CreateElement("add");
                            addElement.SetAttribute("key", n.Name);
                            addElement.SetAttribute("value", n.Value);
                            app.AppendChild(addElement);
                        }
                    }
                }
                objXmlDoc.Save(configPath);
            }
        }
    }
}
