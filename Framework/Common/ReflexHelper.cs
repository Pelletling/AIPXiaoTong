using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Framework.Common
{
    public static class ReflexHelper
    {
        public static string GetPropertyValue<T>(T t, string propertyName)
        {
            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyName);

            if (property == null) return string.Empty;

            object o = property.GetValue(t, null);

            if (o == null) return string.Empty;

            return o.ToString();
        }

        public static void SetPropertyValue<T>(T t, string propertyName, object value)
        {
            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyName);

            if (property == null)
                return;

            property.SetValue(t, value, null);
             
        }
    }
}
