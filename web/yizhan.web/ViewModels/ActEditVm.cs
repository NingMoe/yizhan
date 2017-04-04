using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yizhan.web.Models;

namespace yizhan.web.ViewModels
{
    public class ActEditVm:BaseVm
    {
        public ActEditVm(int fid,int parentFid)
        {
            _fid = fid;
            _parentFid = parentFid;
        }

        private Act _act;
        /// <summary>
        /// 活动项目
        /// </summary>
        public Act Act
        {
            get { return _act ?? (_act = ActDal.GetModel(Fid)); }
        }

        private int _fid;
        /// <summary>
        /// 活动项目id
        /// </summary>
        public int Fid { get { return _fid; } }

        private int _parentFid;
        /// <summary>
        /// 父级活动项目id
        /// </summary>
        public int ParentFid { get { return _parentFid;} }

        private Act _parentAct;
        /// <summary>
        /// 父级活动项目
        /// </summary>
        public Act ParentAct
        {
            get
            {
                return _parentAct ?? (_parentAct=ActDal.GetModel(ParentFid));
            }
        }
    }
}