using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using com.ccfw.Dal.Base;
using com.ccfw.Utility;
using yizhan.web.Models;

namespace yizhan.web.Dal
{
    public class ActDal:BaseDAL<Act>
    {
        public ReMsg UploadPic(HttpPostedFileBase filePosted)
        {
            if (filePosted.ContentLength <= 0)
            {
                return ReMsg(false, "没有任何文件");
            }

            return UploadPic(filePosted.InputStream);
        }

        /// <summary>
        /// 制作指定大小缩略图
        /// </summary>
        /// <param name="descWidth"></param>
        /// <param name="descHeight"></param>
        public static bool MakeThumbnail(Stream stream, string savePath, int descWidth, int descHeight, long quality, string imageCodec = "JPEG")
        {
            Bitmap descBm = null;
            Graphics descGh = null;
            Image fromimg = null;
            try
            {
                fromimg = Image.FromStream(stream);
                descBm = new Bitmap(fromimg.Width, fromimg.Height);
                descGh = Graphics.FromImage(descBm);

                var tFormat = descBm.RawFormat;
                long[] qy = { quality }; //设置压缩的比例1-100 
                var ep = new EncoderParameters();
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);

                var iciInfo = ImageCodecInfo.GetImageEncoders().FirstOrDefault(_ => _.FormatDescription.Equals(imageCodec));

                descGh.DrawImage(Image.FromStream(stream), new Rectangle(0, 0, fromimg.Width, fromimg.Height));

                if (iciInfo != null)
                    descBm.Save(savePath, iciInfo, ep);
                else
                    descBm.Save(savePath, tFormat);

                fromimg.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (fromimg != null)
                    fromimg.Dispose();

                if (descBm != null)
                    descBm.Dispose();

                if (descGh != null)
                    descGh.Dispose();
            }
        }

        public ReMsg UploadPic(Stream stream)
        {
            string saveBase = SiteConfig.PhotoBasePath;

            var now = DateTime.Now;
            string fileUrl = string.Format("{0}/{1}/{2}/{3}/", saveBase, now.Year, now.Month, now.Day);
            string filePath = HttpContext.Current.Server.MapPath("~" + fileUrl);
            string fileName = DateTime.Now.ToString("hhmmss") + new Random().Next(1, 1000) + ".jpg";
            

            CDirectory.Create(filePath);
            var fileFullName = Path.Combine(filePath, fileName);
            var b = MakeThumbnail(stream, fileFullName, 1280, 854, 80);
            return ReMsg(b, b ? fileUrl + fileName : "缩略图存储失败");
        }

        /// <summary>
        /// 添加保存
        /// </summary>
        /// <returns></returns>
        public ReMsg EditAct(Act model)
        {
            if (model.Id > 0)
            {
                return UpdateAct(model);
            }
            else
            {
                return AddAct(model);
            }
        }

        /// <summary>
        /// 新增活动项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private ReMsg AddAct(Act model)
        {
            if (model.ParentFid > 0)
            {
                var parentAct = GetModel(model.ParentFid);
                if (parentAct == null)
                    return ReMsg(false, "父级活动项目不存在");

                if (parentAct.Depth >= 3)
                    return ReMsg(false, "超出板块层级最大限制");

                model.Depth = parentAct.Depth +1;
                model.RootFid = parentAct.RootFid;
            }
            else
            {
                model.RootFid = 0;
                model.Depth = 1;
            }

            model.Id = Add(model);

            if (model.RootFid == 0)
            {
                model.RootFid = model.Id;
                Update(model, "RootFid");
            }

            return ReMsg(true, "新增成功");
        }

        /// <summary>
        /// 修改活动项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private ReMsg UpdateAct(Act model)
        {
            var act = GetModel(model.Id);
            if (act == null)
                return ReMsg(false, "指定活动项目不存在");

            act.Enable = model.Enable;
            act.Name = model.Name;
            act.OrderIndex = model.OrderIndex;
            act.PhotoUrl = model.PhotoUrl;

            Update(act);

            return ReMsg(true, "修改成功");
        }

        /// <summary>
        /// 删除活动项目
        /// </summary>
        /// <returns></returns>
        public ReMsg DeleteAct(int id)
        {
            var act = GetModel(id);
            if (act == null)
                return ReMsg(false, "指定活动项目不存在");

            var b=DeleteInner(id);
            if (!b)
                return ReMsg(false, "删除失败");
            Delete(id);

            return ReMsg(true,"删除成功");
        }

        /// <summary>
        /// 递归删除子项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DeleteInner(int id)
        {
            var list = GetList("ParentFId=" + id,500,1,false,"Id");
            foreach (var item in list)
            {
                var b=DeleteInner(item.Id);
                if(!b)
                    return false;
            }

            Delete(id);

            return true;
        }
    }
}