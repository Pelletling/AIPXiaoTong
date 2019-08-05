using System.Collections.Generic;

namespace Framework.Collections
{
    public class NameValue
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public NameValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
    /// <summary>
    /// 对象比较器
    /// </summary>
    public class Comparer : IComparer<NameValue>
    {
        public int Compare(NameValue x, NameValue y)
        {
            if (x.Name == y.Name)
                return string.Compare(x.Value, y.Value);
            else
                return string.Compare(x.Name, y.Name);
        }
    }
}
