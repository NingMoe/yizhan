using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yizhan.web.Controllers.admin
{
    public class HomeController : Controller
    {
        //页面框架
        public ActionResult Index()
        {
            return View();
        }

        //左侧导航
        public ActionResult Left()
        {
            return View();
        }

        /// <summary>
        /// 顶部
        /// </summary>
        /// <returns></returns>
        public ActionResult Top()
        {
            return View();
        }
    }
}