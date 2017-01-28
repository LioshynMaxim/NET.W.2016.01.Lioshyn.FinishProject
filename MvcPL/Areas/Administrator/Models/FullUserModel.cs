using System.Collections.Generic;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Models
{
    public class FullUserModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public IEnumerable<RoleModel> Role { get; set; }
        public IEnumerable<MailModel> Mail { get; set; }
        public TeacherModel Teacher { get; set; }
        public PupilModel Pupil { get; set; }
        public ParentModel Parent { get; set; }
    }
}