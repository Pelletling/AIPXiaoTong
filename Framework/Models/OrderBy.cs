using System;
using System.Linq.Expressions;

namespace Framework.Models
{
    public class OrderBy<T> where T : class
    {
        public Expression<Func<T, object>> Order { get; set; }
        public bool Desc { get; set; }
    }
}
