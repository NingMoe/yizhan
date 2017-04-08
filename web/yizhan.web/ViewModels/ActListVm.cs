using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yizhan.web.Dal;
using yizhan.web.Models;

namespace yizhan.web.ViewModels
{
    /// <summary>
    /// 活动项目视图模型
    /// </summary>
    public class ActListVm:BaseVm
    {
        private int _fid;//板块id
        private int _pn;//页数

        public ActListVm(int fid,int pn)
        {
            _fid = fid;
            if (pn < 1)
                pn = 1;

            _pn = pn;
        }

        private int _totalCount;
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount
        {
            get
            {
                if (_totalCount != -1)
                    return _totalCount;

                return _totalCount = ActDal.GetCount(Where);
            }
        }

        private List<Act> _acts;

        /// <summary>
        /// 活动列表
        /// </summary>
        public List<Act> Acts
        {
            get
            {
                return _acts ?? (_acts = ActDal.GetList(Where, PageSize, _pn, false, "*", "OrderIndex"));
            }
        }

        private string _where;

        public string Where
        {
            get
            {
                if(_where!=null)
                    return _where;

                return _where = _fid == 0 ? "Depth=1" : "ParentFId=" + _fid;
            }
        }

        public int PageSize {
            get { return 30; }
        }

        public int Fid { get { return _fid; } }

        public int Pn { get { return _pn;} }

        private List<Act> _parentList;

        public List<Act> ParentList
        {
            get
            {
                if (_parentList != null)
                    return _parentList;

                _parentList = new List<Act>();
                if (Act == null)
                    return _parentList;

                var parent = ActDal.GetModel(Act.ParentFid);
                if (parent != null)
                {
                    _parentList.Add(parent);

                    if (parent.ParentFid > 0)
                    {
                        _parentList.Add(ActDal.GetModel(parent.ParentFid));
                    }
                }
                _parentList = _parentList.OrderBy(_ => _.Depth).ToList();

                return ParentList;
            }
        }

        private Act _act;

        public Act Act
        {
            get { return _act ?? (_act = ActDal.GetModel(Fid)); }
        }
    }
}