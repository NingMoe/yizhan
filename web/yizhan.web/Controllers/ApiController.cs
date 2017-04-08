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
        /// 获取活动
        /// </summary>
        /// <returns></returns>
        public ActionResult Acts()
        {
            return Json(ActDal.GetList("Enable=1 and Depth=1",3,1,true,"*","OrderIndex"),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取环节
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public ActionResult Steps(int fid)
        {
            var act = ActDal.GetModel(fid);
            if (act == null)
                return Json(null);

            if (act.Depth == 1)
                fid = act.Id;
            else if (act.Depth == 2)
                fid = act.ParentFid;

            return Json(ActDal.GetList(string.Format("Enable=1 and ParentFid={0}", fid), 10, 1, true, "*", "OrderIndex"), JsonRequestBehavior.AllowGet);
        }

       /// <summary>
       /// 获取照片
       /// </summary>
       /// <param name="fid"></param>
       /// <param name="pn"></param>
       /// <returns></returns>
        public ActionResult Photos(int fid,int pn=1)
       {
           var act = ActDal.GetModel(fid);
            if(act==null)
                return Json(null);

           var where = "";
           if (act.Depth == 1)
               where = string.Format("RootFid={0} and Depth=3",fid);
            else
               where = string.Format("ParentFid={0}", fid);

           return Json(ActDal.GetList(string.Format("Enable=1 and {0}", where), 32, pn, true, "*", "OrderIndex"), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取照片总数
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public ActionResult PhotosCount(int fid)
        {
             return Json(ActDal.GetCount(string.Format("Enable=1 and ParentFid={0}", fid)),JsonRequestBehavior.AllowGet);
        }

        private ActDal _actDal;
        public ActDal ActDal { get { return _actDal ?? (_actDal = new ActDal()); } }
    }
}