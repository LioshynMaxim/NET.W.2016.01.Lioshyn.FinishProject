using System.Collections.Generic;

namespace BLL.Interfacies.Entities
{
    public class FullClassRoomEntity
    {
        public ClassRoomEntity ClassRoom { get; set; }
        public IEnumerable<UserPupilEntity> Pupil { get; set; }
        public UserTeacherEntity Teacher { get; set; }
    }
}
