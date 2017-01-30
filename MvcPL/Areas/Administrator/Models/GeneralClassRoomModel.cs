using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Models
{
    public class GeneralClassRoomModel
    {
        public ClassRoomModel ClassRoom { get; set; }
        public IEnumerable<PupilModel> Pupil { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}