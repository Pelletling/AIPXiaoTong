using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Framework.Common
{
 public static   class DataTableHelper
    {
        public static string GetValue(this DataRow row,string ColName)
        {
            if (row.Table.Columns.Contains(ColName))
            {
                return row[ColName].ToString().Trim();
            }

            return "";
        }

    }
}
