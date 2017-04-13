using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yizhan.web.Models;

namespace yizhan.web.ViewModels
{
    public class EditPwVm:BaseVm
    {
        private AdminUser _admin;
        /// <summary>
        /// 管理员
        /// </summary>

        public AdminUser Admin
        {
            get
            {
                return _admin??(_admin=new AdminUser());
            }
        }

    }
}