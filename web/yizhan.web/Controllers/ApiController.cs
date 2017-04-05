using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yizhan.web.Dal;

namespace yizhan.web.Controllers
{
    /// <summary>
    /// 微信小程序接口
    /// </summary>
    public class ApiController : Controller
    {
        /// <summary>
        /// 获取活动页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Acts(int fid=0)
        {
            return Json(ActDal.GetList("Enable=1",3,1,true,"*","OrderIndex"),JsonRequestBehavior.AllowGet);
        }

        private ActDal _actDal;
        public ActDal ActDal { get { return _actDal ?? (_actDal = new ActDal()); } }
    }
}