using System.Collections.Generic;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Models
{
    public class FullPupilModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public TeacherModel Teacher { get; set; }
        public PupilModel Pupil { get; set; }
        public ClassRoomModel ClassRoom { get; set; }
        public IEnumerable<ParentModel> Parent { get; set; }
    }
}