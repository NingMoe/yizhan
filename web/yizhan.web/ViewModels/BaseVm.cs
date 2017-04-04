using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using yizhan.web.Dal;

namespace yizhan.web.ViewModels
{
    /// <summary>
    /// 视图模型基类
    /// </summary>
    public class BaseVm
    {
        public string PageTitle { get; set; }

        #region other
        private ActDal _actDal;
        public ActDal ActDal
        {
            get
            {
                return _actDal ?? (_actDal = new ActDal());
            }
        }
        #endregion
    }
}