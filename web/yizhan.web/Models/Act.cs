using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.ccfw.Model.Base;

namespace yizhan.web.Models
{
    public class Act:BaseModel
    {
        public Act()
        {
            PrimaryKey = "Id";
            IsAutoId = true;
            ConnName = DbEnum.yizhan.ToString();
        }
        /// <summary>
        /// 自动标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序最大在最前
        /// </summary>
        public int OrderIndex { get; set; }

        /// <summary>
        /// 图片url
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 深度 从1开始
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// 父级活动项目Id
        /// </summary>
        public int ParentFid { get; set; }

        /// <summary>
        /// 根节点
        /// </summary>
        public int RootFid { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }
    }
}