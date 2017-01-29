using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Models
{
    public class FullClassroomModel
    {
        public UserModel User { get; set; }
        public IEnumerable<TeacherModel> Teacher { get; set; }
        public IEnumerable<ClassRoomModel> ClassRoom { get; set; }
        public IEnumerable<PupilModel> Pupil { get; set; }
    }
}