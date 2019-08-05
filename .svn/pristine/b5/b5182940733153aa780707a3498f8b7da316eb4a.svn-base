using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Framework.Common
{
    public static class EnumHelper
    {
        /// <summary>
        /// 反射属性的Description值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 反射属性的Category值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCategory(this Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    CategoryAttribute attr = Attribute.GetCustomAttribute(fieldInfo, typeof(CategoryAttribute), false) as CategoryAttribute;
                    if (attr != null)
                    {
                        return attr.Category;
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 获取枚举的名称
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string ToName(this Enum e)
        {
            return Enum.GetName(e.GetType(), e);
        }

        //public static string ToEnumDesc(this string Name,Type type)
        //{
        //    return ((Enum)Enum.Parse(type.GetType(), Name)).ToDescription();
        //}

        /// <summary>
        /// 将枚举转换成list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumEntity> EnumToList<T>()
        {
            List<EnumEntity> list = new List<EnumEntity>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                EnumEntity m = new EnumEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.Description = da.Description;
                }
                m.EnumValue = Convert.ToInt32(e);
                m.EnumName = e.ToString();
                list.Add(m);
            }
            return list;
        }
        public class EnumEntity
        {
            /// <summary>  
            /// 枚举的描述  
            /// </summary>  
            public string Description { set; get; }

            /// <summary>  
            /// 枚举名称  
            /// </summary>  
            public string EnumName { set; get; }

            /// <summary>  
            /// 枚举对象的值  
            /// </summary>  
            public int EnumValue { set; get; }
        }
    }
}
