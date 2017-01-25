using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IClassRoomService : IService<ClassRoomEntity>
    {
        IEnumerable<ClassRoomEntity> GetTeacherClassRooms(int idTeacher);
        IEnumerable<ClassRoomEntity> GetPupilClassRooms(int idPupil);
    }
}