using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.ccfw.Dal.Base;
using com.ccfw.Utility;
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
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PhotoImport(int fid,string path)
        {
            var actDal = new ActDal();
            var act = actDal.GetModel(fid);
            if (act == null)
                return Json("环节不存在");

            if (act.Depth != 2)
                return Json("该项目不属于环节");

            path = Server.MapPath("~/upload/");
            if(!Directory.Exists(path))
                return Json("路径不存在");

            var folder = new DirectoryInfo(path);
            var types = new[] { "jpg", "jpeg", "gif", "png","bmp" };
            var files=folder.GetFiles().OrderBy(_ => _.Name).ToList();
            foreach (var file in files)
            {
                if (!types.Contains(file.Extension, StringComparer.OrdinalIgnoreCase))
                    continue;

                var re=actDal.UploadPic(file.OpenRead());
                if (!re.Success)
                {
                    return Json(false,string.Format("照片名为{0}未保存成功,原因{1},可以继续点导入重试",file.Name,re.Info));
                }

                var photo = new Act{Name = file.Name,ParentFid = fid,PhotoUrl = re.Info,Enable = true,OrderIndex = ConvertHelper.StrToInt(file.Name)};
                re=actDal.EditAct(photo);
                if (!re.Success)
                {
                    return Json(false, string.Format("照片名为{0}未保存成功,原因{1},可以继续点导入重试", file.Name, re.Info));
                }
            }

            return Json("全部导入成功");
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