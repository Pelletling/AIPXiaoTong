﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class QueryHouseTypeShowListResponse:BaseResponse
    {
        public int pagecount { get; set; }
        public int pageindex { get; set; }
        public int pagesize { get; set; }
        public List<QueryHouseTypeShowList> housetypeshowlist { get; set; }

        public class QueryHouseTypeShowList
        {
            public string merchantid { get; set; }
            public string merchantname { get; set; }

            /// <summary>
            /// 项目名称
            /// </summary>
            public string projectname { get; set; }
            public string projectid { get; set; }

            /// <summary>
            /// 户型名称
            /// </summary>
            public string housetypename { get; set; }
            public string housetypeshowid { get; set; }

            /// <summary>
            /// 户型面积
            /// </summary>
            public string housetypearea { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
           // public string description { get; set; }

            /// <summary>
            /// 户型缩略图
            /// </summary>
            public string housethumbnailimage { get; set; }

            /// <summary>
            /// 户型展示图
            /// </summary>
            // public string houseshowimage { get; set; }
            public List<string> houseshowimagelist { get; set; }

            /// <summary>
            /// 内容
            /// </summary>
            public string content { get; set; }


        }

    }
}
