using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.ccfw.Dal.Base;
using yizhan.web.Models;

namespace yizhan.web.Controllers.admin
{
    /// <summary>
    /// 后台管理系统页面框架
    /// </summary>
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

        /// <summary>
        /// 登陆界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登陆提交
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoginPost(string user,string pw)
        {
            var parms = new List<DbParam>()
            {
                new DbParam(){ParamDbType = DbType.String,ParamName = "@UserName",ParamValue = user},
                new DbParam(){ParamDbType = DbType.String,ParamName = "@Pw",ParamValue = pw}
            };

            var success = new BaseDAL<AdminUser>().Exists("UserName=@UserName and Pw=@Pw",parms);

            return Json(success);
        }
    }
}