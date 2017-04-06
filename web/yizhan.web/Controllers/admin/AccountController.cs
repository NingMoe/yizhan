using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult EditPwPost(int userid, string oldPw, string newPw)
        {
            return Json(true);
        }
    }
}