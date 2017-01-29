using System.Collections.Generic;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Models
{
    public class FullTeacherModel
    {
        public UserModel User { get; set; }
        public TeacherModel Teacher { get; set; }
        public IEnumerable<ClassRoomModel> ClassRoom { get; set; }
    }
}