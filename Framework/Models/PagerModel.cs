using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Models
{
    public class PagerModel
    {
        public int TotalItemCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}
