using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;
using System.Configuration;
using System.IO;

namespace Framework.Web.IOC
{
    public class DIFactory
    {
        private static object _SyncHelper = new object();
        private static Dictionary<string, IUnityContainer> _UnityContainerDictionary = new Dictionary<string, IUnityContainer>();

        /// <summary>
        /// 根据containerName获取指定的container
        /// </summary>
        /// <param name="containerName">配置的containerName，默认为defaultContainer</param>
        /// <returns></returns>
        public static IUnityContainer GetContainer(string containerName = "Container")
        {
            if (!_UnityContainerDictionary.ContainsKey(containerName))
            {
                lock (_SyncHelper)
                {
                    if (!_UnityContainerDictionary.ContainsKey(containerName))
                    {
                        //配置UnityContainer
                        IUnityContainer container = new UnityContainer();
                        ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                        //fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");
                        fileMap.ExeConfigFilename = Path.Combine(GetConfigFile());
                        System.Configuration.Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                        UnityConfigurationSection configSection = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                        configSection.Configure(container, containerName);

                        _UnityContainerDictionary.Add(containerName, container);
                    }
                }
            }
            return _UnityContainerDictionary[containerName];
        }

        private static string GetConfigFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml";
            if (File.Exists(path))
                return path;
             
            path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + "\\CfgFiles\\Unity.Config.xml";            
            if (File.Exists(path))
                return path;

            throw new Exception("未找到配置文件Unity.Config.xml");
        }
        
    }
}
