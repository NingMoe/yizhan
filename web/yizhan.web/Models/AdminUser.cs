using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.ccfw.Model.Base;

namespace yizhan.web.Models
{
    public class AdminUser:BaseModel
    {
        public AdminUser()
        {
            PrimaryKey = "Id";
            IsAutoId = true;
            ConnName = DbEnum.yizhan.ToString();
        }
        /// <summary>
        /// 标识id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pw { get; set; }
    }
}