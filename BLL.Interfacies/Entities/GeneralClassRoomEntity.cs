using System.Collections.Generic;

namespace BLL.Interfacies.Entities
{
    public class GeneralClassRoomEntity
    {
        public ClassRoomEntity ClassRoom { get; set; }
        public IEnumerable<PupilEntity> Pupil { get; set; }
        public TeacherEntity Teacher { get; set; }
    }
}
