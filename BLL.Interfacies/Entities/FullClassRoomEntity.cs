using System.Collections.Generic;

namespace BLL.Interfacies.Entities
{
    public class FullClassRoomEntity
    {
        public UserEntity User { get; set; }
        public IEnumerable<TeacherEntity> Teacher { get; set; }
        public IEnumerable<ClassRoomEntity> ClassRoom { get; set; }
        public IEnumerable<PupilEntity> Pupil { get; set; }
    }
}
