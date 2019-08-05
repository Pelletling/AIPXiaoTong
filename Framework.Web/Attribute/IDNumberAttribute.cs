using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Framework.Common;

namespace Framework.Web
{
    public class IDNumberAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0}不合法", name);
        }

        public IDNumberAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var text = value as string;

            if (string.IsNullOrWhiteSpace(text))
                return true;

            return StringHelper.IsIDNumber(text);
        }

      
    }
}
