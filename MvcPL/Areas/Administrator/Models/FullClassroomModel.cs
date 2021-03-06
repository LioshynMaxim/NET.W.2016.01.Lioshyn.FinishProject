﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPL.Areas.Administrator.Models.Mersh;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Models
{
    public class FullClassroomModel
    {
        public ClassRoomModel ClassRoom { get; set; }
        public IEnumerable<UserPupilModel> Pupil { get; set; }
        public UserTeacherModel TeacherModel { get; set; }
        
    }
}