using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.ccfw.Dal.Base;
using yizhan.web.Models;
using yizhan.web.ViewModels;

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
            var model=new EditPwVm();
            return View(model);
        }

        public ActionResult EditPwPost(string oldPw, string newPw)
        {
            var adminUserDal=new BaseDAL<AdminUser>();
            var user = adminUserDal.GetModel("Id=1");
            if (user == null)
                return Json(new ReMsg() { Success = false, Info = "用户不存在" });

            if(user.Pw!=oldPw)
                return Json(new ReMsg(){Success = false,Info = "密码不正确"});

            user.Pw = newPw;
            adminUserDal.Update(user);
            return Json(true);
        }
    }
}