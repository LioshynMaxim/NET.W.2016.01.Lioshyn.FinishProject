using System.Collections.Generic;

namespace BLL.Interfacies.Entities
{
    public class FullTeacherEntity
    {
        public UserEntity User { get; set; }
        public TeacherEntity Teacher { get; set; }
        public IEnumerable<ClassRoomEntity> ClassRoom { get; set; }
    }
}
