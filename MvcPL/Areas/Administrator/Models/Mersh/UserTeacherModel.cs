using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Models.Mersh
{
    public class UserTeacherModel
    {
        public UserModel User { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}