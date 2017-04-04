using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yizhan.web.Models
{
    public class YzUrlHelper
    {
        public static string PhotoUrl(string photoUrl)
        {
            return SiteConfig.PhotoBasePath + "/" + photoUrl;
        }
    }
}