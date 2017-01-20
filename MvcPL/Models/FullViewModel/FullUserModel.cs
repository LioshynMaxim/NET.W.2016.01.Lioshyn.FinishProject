using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models.FullViewModel
{
    public class FullUserModel
    {
        public IEnumerable<UserModel> Users { get; set; }
        public IEnumerable<RoleModel> Roles { get; set; }
    }
}