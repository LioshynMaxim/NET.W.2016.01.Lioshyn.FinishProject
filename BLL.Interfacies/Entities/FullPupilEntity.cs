using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class FullPupilEntity
    {
        public int Id { get; set; }
        public UserEntity User { get; set; }
        public TeacherEntity Teacher { get; set; }
        public ClassRoomEntity ClassRoom { get; set; }
        public PupilEntity Pupil { get; set; }
        public IEnumerable<ParentEntity> Parent { get; set; }
    }
}
