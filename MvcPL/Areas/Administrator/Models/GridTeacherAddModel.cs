using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Models
{
    public class GridTeacherAddModel
    {
        public int IdUser { get; set; }
        public ClassRoomModel ClassRoom { get; set; }
    }
}