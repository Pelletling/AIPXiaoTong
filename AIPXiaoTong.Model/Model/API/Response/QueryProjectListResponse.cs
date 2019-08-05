﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class QueryProjectListResponse : BaseResponse
    {

        public int pagecount { get; set; }
        public int pageindex { get; set; }
        public int pagesize { get; set; }
        public List<ProjectList> projectlist { get; set; }

        public class ProjectList
        {

            public string merchantname { get; set; }
            public string merchantid { get; set; }

            /// <summary>
            /// 项目名称
            /// </summary>
            public string projectname { get; set; }
            public string projectid { get; set; }

            /// <summary>
            /// 项目图片
            /// </summary>
            public string projectimage { get; set; }

            /// <summary>
            /// 广告图片
            /// </summary>
            public string advertisingimge { get; set; }
            //public List<String> advertisingimgelist { get; set; }

            /// <summary>
            /// 项目金额
            /// </summary>
            public string projectamount { get; set; }

            /// <summary>
            /// 剩余认筹额度
            /// </summary>
            public string residueamount { get; set; }

            /// <summary>
            /// 截止日期
            /// </summary>
            public string deadline { get; set; }

            /// <summary>
            /// 简短描述
            /// </summary>
            public string description { get; set; }

            /// <summary>
            /// 未通过原因
            /// </summary>
            public string reason { get; set; }

            public string status { get; set; }

            public string statusdesc { get; set; }
            public string provincecode { get; set; }
            public string provincename { get; set; }
            public string citycode { get; set; }
            public string cityname { get; set; }
           
            

        }
    }
}
