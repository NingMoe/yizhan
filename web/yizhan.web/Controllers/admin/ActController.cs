using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yizhan.web.Dal;
using yizhan.web.Models;
using yizhan.web.ViewModels;

namespace yizhan.web.Controllers.admin
{
    public class ActController : Controller
    {
        /// <summary>
        /// 活动项目页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ActList(int fid=0,int pn=1)
        {
            var model = new ActListVm(fid,pn);
            return View(model);
        }

        /// <summary>
        /// 添加/编辑活动项目
        /// </summary>
        /// <param name="fid"></param>
        /// <param name="parentFid"></param>
        /// <returns></returns>
        public ActionResult ActEdit(int fid=0,int parentFid=0)
        {
            var model=new ActEditVm(fid,parentFid);
            if (fid>0&&model.Act == null)
                return Content("找不到活动项");

            if (parentFid > 0 && model.ParentAct==null)
                return Content("找不到父级活动项");

            return View(model);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadPhoto(HttpPostedFileBase file)
        {
            return Json(new ActDal().UploadPic(file));
        }

        /// <summary>
        /// 保存活动项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ActEditPost(Act model)
        {
            return Json(new ActDal().EditAct(model));
        }

        /// <summary>
        /// 删除活动项目
        /// </summary>
        /// <returns></returns>
        public ActionResult DeletePost(int fid)
        {
            return Json(new ActDal().DeleteAct(fid));
        }
    }
}