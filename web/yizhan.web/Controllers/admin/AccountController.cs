using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.ccfw.Dal.Base;
using yizhan.web.Models;

namespace yizhan.web.Controllers.admin
{
    /// <summary>
    /// 后台用户
    /// </summary>
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult EditPw()
        {
            return View();
        }

        public ActionResult EditPwPost(string oldPw, string newPw)
        {
            var adminUserDal=new BaseDAL<AdminUser>();
            var user = adminUserDal.GetModel("Id=1");
            if (user == null)
                return Json(false);


            return Json(true);
        }
    }
}