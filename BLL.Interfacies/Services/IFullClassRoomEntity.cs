using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IFullClassRoomEntity
    {
        IEnumerable<UserPupilEntity> GetPupil(int idUser);
        IEnumerable<UserTeacherEntity> GetTeacher(int idUser);
        FullClassRoomEntity GetClassRoom(int idClassRoom);
        IEnumerable<FullClassRoomEntity> GetAllInformationClassRoom();
    }
}