using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yizhan.web.Models
{
    public class SiteConfig
    {
        /// <summary>
        /// 照片存放路径
        /// </summary>
        public static string PhotoBasePath
        {
            get { return "/photo"; }
        }
    }
}