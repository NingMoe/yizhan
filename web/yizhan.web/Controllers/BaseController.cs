using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.ccfw.Dal.Base;

namespace yizhan.web.Controllers
{
    public class BaseController:Controller
    {
        public ActionResult ReJson(bool success,string info,object data=null)
        {
            return Json(new ReMsg() { Success = success, Info = info, Data = data });
        }
    }
}