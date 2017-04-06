using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.ccfw.Utility;

namespace yizhan.web.App_Code
{
    /// <summary>
    /// 授权过滤器
    /// </summary>
    public class AuthAttribute:IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var name=CookieHelper.GetCookie("uid");
            if(string.IsNullOrEmpty(name))
                filterContext.Result=new RedirectResult("Home/Login");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}