using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IClassRoomService : IService<ClassRoomEntity>
    {
        IEnumerable<ClassRoomEntity> GetTeacherClassRooms(int idTeacher);
        ClassRoomEntity GetPupilClassRoom(int idPupil);
    }
}