using System.Collections.Generic;

namespace BLL.Interfacies.Entities
{
    public class FullUserEntity
    {
        public int Id { get; set; }
        public UserEntity User { get; set; }
        public IEnumerable<RoleEntity> Role { get; set; }
        public IEnumerable<MailEntity> Mail { get; set; }
        public TeacherEntity Teacher { get; set; }
        public PupilEntity Pupil { get; set; }
        public ParentEntity Parent { get; set; }
    }
}