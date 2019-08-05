using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Framework.Common
{
    public class XmlHelper
    {
        public static string XmlSerializer<T>(T t, bool omitXmlDeclaration = true, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            XmlWriterSettings settings = new XmlWriterSettings();
            //去除xml声明
            settings.OmitXmlDeclaration = omitXmlDeclaration;
            settings.Encoding = encoding;
            System.IO.MemoryStream mem = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(mem, settings))
            {
                //去除默认命名空间xmlns:xsd和xmlns:xsi
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                XmlSerializer formatter = new XmlSerializer(t.GetType());

                formatter.Serialize(writer, t, ns);
            }
            return encoding.GetString(mem.ToArray());
        }



        public static T XmlDeserialize<T>(string str, Encoding encoding = null) where T : class
        {
            object obj;
            using (System.IO.MemoryStream mem = new MemoryStream(encoding == null ? Encoding.UTF8.GetBytes(str) : encoding.GetBytes(str)))
            {
                using (XmlReader reader = XmlReader.Create(mem))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(T));
                    obj = formatter.Deserialize(reader);
                }
            }
            return obj as T;
        }

        public static bool IsXml(string xml)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
